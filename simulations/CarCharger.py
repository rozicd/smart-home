from datetime import datetime
import threading
import time
import paho.mqtt.client as mqtt
from SmartDevice import SmartDevice
import random

class CarCharger(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.battery_info_topic = name+"/info"
        self.charging_power = 0
        self.number_of_connectors = 0
        self.connectors = []
        self.client.publish(self.name+"/"+"plugged", f"Car connected on connector :")
        self.start_sim = None
        self.start_charge = None

    def run_simulation(self) :
        while True :
            rsleep = random.uniform(10, 60)
            print(self.connectors)
            for index, c in enumerate(self.connectors):
                if c is None:
                    car = Car(self.name+"/"+str(index))
                    print("Plugged")
                    self.client.publish(self.name+"/"+"plugged", f"connected:{index}")
                    self.connectors[index] = car
                    break
            time.sleep(rsleep)

    def run_charge(self) :
        time.sleep(10)
        while True :
            for index, c in enumerate(self.connectors):
                    time.sleep(2)
                    if c is not None:
                        charging_rate = (self.charging_power / c.battery_size) * 100
                        c.battery_procentage += charging_rate
                        print(self.name +"/spending",f"{self.charging_power/60}")
                        self.client.publish(self.name +"/spending", f"{self.charging_power/60}")
                        c.battery_spent += self.charging_power/60
                        c.publish_battery()
                        if c.battery_procentage >= c.treshold :
                            c.left()
                            self.client.publish(self.name+"/"+"plugged", f"disconnected:{str(round(c.battery_spent,3))}")
                            self.connectors[index] = None
            time.sleep(60)
                

        

    def on_message(self, client, userdata, msg):
        if msg.topic == self.name +"/recive":
            super().on_message(client, userdata, msg)
        if msg.topic == self.name +"/info":
            info = msg.payload.decode('utf-8').split(',')
            power = float(info[0])
            chargers = int(info[1])
            self.charging_power = power
            self.number_of_connectors = chargers
            self.connectors = [None]*chargers
            print("Charger",self.charging_power)
            print("Charger",self.number_of_connectors)
            self.start_sim = threading.Thread(target=self.run_simulation)
            self.start_sim.start()
            self.start_sim_charge = threading.Thread(target=self.run_charge)
            self.start_sim_charge.start()
           




    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        self.client.subscribe(self.battery_info_topic)
        print(f"Subscribed to topic: {self.battery_info_topic}")

class Car() :
    def __init__(self,name):
        self.broker_address = "localhost"
        self.broker_port = 8883
        self.client = mqtt.Client(clean_session=True)
        self.client.on_message = self.on_message
        self.client.connect(self.broker_address, self.broker_port, 60)
        print(name+"/"+"treshold")
        self.client.subscribe(name+"/"+"treshold")
        self.loop_thread = threading.Thread(target=self.run)
        self.loop_thread.start()

        self.battery_spent = 0
        self.name = name
        self.treshold = 100
        self.battery_procentage = random.uniform(10, 40)
        self.battery_size = random.uniform(40, 80)

    def publish_battery(self):
        print("car procentage",f"{self.battery_procentage}/{self.treshold}")
        self.client.publish(self.name, str(self.name)+","+str(round(self.battery_procentage,2))+"/"+str(self.treshold))


    def on_message(self, client, userdata, msg):
        print("BLAAA")
        command = msg.payload.decode('utf-8')
        treshold = float(command)
        self.treshold = treshold

    def run(self) :
        self.client.loop_start()

    def left(self):
        self.client.publish(self.name, str(self.name)+","+"")
        self.client.disconnect()
        self.loop_thread.join()


        

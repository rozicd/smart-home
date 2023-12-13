import threading
import time
import paho.mqtt.client as mqtt
import random

from Lamp import Lamp
from SmartDevice import SmartDevice
from SolarPanelSystem import SolarPanelSystem
from HomeBattery import HomeBattery


class SmartHome:
    def __init__(self,id):
        self.id = id
        self.broker_address = "localhost"
        self.broker_port = 8883

        self.client = mqtt.Client(clean_session=True)
        self.client.unsubscribe("#")
        self.client.on_connect = self.on_connect
        self.client.on_message = self.on_message
        self.topicRecive = self.id+"/create"
        self.devices = {}
        self.deviceThreads = {}
        self.running = True
        self.home_battery = None
        self.from_grid = 0
        self.house_power_topic = self.id + "/house_power"
        self.battery_level_topic = self.id + "/battery_level"
        self.panel_system = None

        self.client.connect(self.broker_address, self.broker_port, 60)

    def on_connect(self, client, userdata, flags, rc):
        print(f"Connected with result code {rc}")
        self.client.subscribe(self.topicRecive)
        print(f"Subscribed to topic: {self.topicRecive}")

    def on_message(self, client, userdata, msg):
        recived = msg.payload.decode('utf-8')
        if msg.topic.endswith("/power"):
            print("RECIVED POWER",recived)
            if self.home_battery is not None and self.home_battery.capacity != 0:
                self.home_battery.current_level += (float(recived)/self.home_battery.capacity)*100
                if self.home_battery.current_level > 100 :
                    self.home_battery.current_level = 100
                print("LEVEL= ",self.home_battery.current_level)
                self.client.publish(self.house_power_topic, f"Battery Charged To {self.home_battery.current_level}%")
                self.client.publish(self.battery_level_topic, f"{round(self.home_battery.current_level,1)}")


            else :
                self.from_grid += float(recived)
                self.client.publish(self.house_power_topic, f"No Battery, {recived} sent to Grid")

        else :
            command = recived.split(',')
            device_key = self.id+"/device/"+command[0]
            smart_device = None
            if command[0] not in self.devices.keys():

                if command[1] == 'SolarPanelSystem' :
                    if self.panel_system == None :
                        smart_device = SolarPanelSystem(device_key)
                        self.panel_system = smart_device
                    self.client.subscribe(device_key+'/power')
                elif command[1] == 'HomeBattery' :
                    if self.home_battery == None :
                        smart_device = HomeBattery(device_key)
                        self.home_battery = smart_device

                elif command[1] == 'Lamp':
                    smart_device = Lamp(device_key)
                else:
                    smart_device = SmartDevice(device_key)

                self.devices[command[0]] = smart_device
                if command[0] not in self.deviceThreads and smart_device != None:
                    self.deviceThreads[command[0]] = threading.Thread(target=self.devices[command[0]].run)
                    self.deviceThreads[command[0]].start()





    def run(self):
        self.client.loop_start()
        while True:
            pass


    def sendStatus(self):
        while self.running:
            print("PROPERTY:" + self.id + "-online")
            time.sleep(5)



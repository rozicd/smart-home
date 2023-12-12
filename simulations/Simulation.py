import threading
import time
import paho.mqtt.client as mqtt
import random
from SmartHome import SmartHome

class Simulation:
    def __init__(self):
        self.broker_address = "localhost"
        self.broker_port = 8883


        self.client = mqtt.Client()
        self.client.on_connect = self.on_connect
        self.client.on_message = self.on_message
        self.topicRecive = "property/create"
        self.properties = {}
        self.propertyThreads = {}

        self.client.connect(self.broker_address,self.broker_port,60)


    def on_connect(self, client, userdata, flags, rc):
        print(f"Connected with result code {rc}")
        self.client.subscribe(self.topicRecive)
        print(f"Subscribed to topic: {self.topicRecive}")

    def on_message(self, client, userdata, msg):
        command = msg.payload.decode('utf-8')
        if command not in self.properties.keys():
            print(command)
            self.properties[command]= SmartHome("property/"+command)
            self.propertyThreads[command] = threading.Thread(target=self.properties[command].run)
            self.propertyThreads[command].start()


    def run(self):
        self.client.loop_start() 
        while True:
            pass


if __name__ == "__main__":
    smart = Simulation()
    try:

        run_thread = threading.Thread(target=smart.run)

        run_thread.start()

        run_thread.join()
    except KeyboardInterrupt:
        for thread_name, thread_instance in smart.propertyThreads.items():
            thread_instance.join()

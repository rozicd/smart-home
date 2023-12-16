import threading
import time
import paho.mqtt.client as mqtt
import random

from simulations.CarGate import CarGate
from simulations.Lamp import Lamp
from simulations.SmartDevice import SmartDevice
from simulations.SolarPanelSystem import SolarPanelSystem


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

        self.client.connect(self.broker_address, self.broker_port, 60)

    def on_connect(self, client, userdata, flags, rc):
        print(f"Connected with result code {rc}")
        self.client.subscribe(self.topicRecive)
        print(f"Subscribed to topic: {self.topicRecive}")

    def on_message(self, client, userdata, msg):
        command = msg.payload.decode('utf-8').split(',')
        device_key = self.id+"/device/"+command[0]
        if command[0] not in self.devices.keys():

            if command[1] == 'SolarPanelSystem' :
                smart_device = SolarPanelSystem(device_key)
            elif command[1] == 'Lamp':
                smart_device = Lamp(device_key)
            elif command[1] == "CarGate":
                smart_device = CarGate(device_key)
            else:
                smart_device = SmartDevice(device_key)

            self.devices[command[0]] = smart_device
            if command[0] not in self.deviceThreads:
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



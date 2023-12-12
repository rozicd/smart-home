import threading
import time
import paho.mqtt.client as mqtt
import random

class SmartHome:
    def __init__(self):
        self.broker_address = "localhost"
        self.broker_port = 8883

        self.client = mqtt.Client()
        self.client.on_connect = self.on_connect
        self.client.on_message = self.on_message
        self.topicRecive = "property/create"

        self.client.connect(self.broker_address, self.broker_port, 60)


    def on_connect(self, client, userdata, flags, rc):
        print(f"Connected with result code {rc}")
        self.client.subscribe(self.topicRecive)
        print(f"Subscribed to topic: {self.topicRecive}")

    def on_message(self, client, userdata, msg):
        command = msg.payload.decode('utf-8')
        print(command)

    def run(self):
        self.client.loop_start() 
        while True:
            pass




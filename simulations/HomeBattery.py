from datetime import datetime
import threading
import time
import paho.mqtt.client as mqtt
from SmartDevice import SmartDevice

class HomeBattery(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.battery_info_topic = name+"/info"
        self.current_level = 0
        self.capacity = 0

    def on_message(self, client, userdata, msg):
        if msg.topic == self.name +"/recive":
            super().on_message(client, userdata, msg)
        if msg.topic == self.name +"/info":
            info = msg.payload.decode('utf-8').split(',')
            capacity = float(info[0])
            level = float(info[1])
            self.capacity = capacity
            self.current_level = level



    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        self.client.subscribe(self.battery_info_topic)
        print(f"Subscribed to topic: {self.battery_info_topic}")
import math
import threading
import time
from datetime import datetime

import paho.mqtt.client as mqtt
import random

from SmartDevice import SmartDevice


class AirConditioner(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.ac_info_topic = name + "/info"
        self.ac_current_temperature = 0
        self.powerState = 0
        self.ac_mode = ""
        self.energy_spending = 0
        self.send_ac_tick_thread = None
        self.is_send_ac_thread_running = False
        self.send_ac_energy_thread = None
        self.is_send_ac_energy_running = False
        self.topic_ac = name + "/ac"

    def on_message(self, client, userdata, msg):
        if msg.topic == self.name + "/recive":
            super().on_message(client, userdata, msg)

        if msg.topic == self.name + "/info":
            ac_info = msg.payload.decode("utf-8")
            current_temperature, energy_spending = ac_info.split(',')
            self.energy_spending = float(energy_spending)/1000
            print(self.topic_ac)
            self.start_send_ac_tick_thread()
        elif msg.topic == self.name + "/turnOn":
            self.powerState = 1
            print("Turning on AC")

        elif msg.topic == self.name + "/turnOff":
            self.powerState = 0
            print("Turning off AC")

        elif msg.topic == self.name + "/modeChange":
            ac_info = msg.payload.decode("utf-8")
            current_temperature, mode = ac_info.split(',')
            self.ac_mode = mode
            self.ac_current_temperature = current_temperature
            print("Updating Ac mode")

    def start_send_ac_tick_thread(self):
        print("pre ifa")
        if not self.is_send_ac_energy_running:
            print("posle ifa")
            self.is_send_ac_thread_running = True
            self.send_ac_tick_thread = threading.Thread(target=self.send_ac_info)
            self.send_ac_tick_thread.start()

    def send_ac_info(self):
        while self.is_send_ac_thread_running:
            print("################AAAAAAAAAAAAAAAa")
            print(self.topic_ac)
            self.client.publish(self.topic_ac, f"{self.ac_current_temperature}, {self.powerState}")
            time.sleep(5)

    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        print("AC SUBSCRIBED")
        self.client.subscribe(self.ac_info_topic)
        self.client.subscribe(self.name + "/turnOn")
        self.client.subscribe(self.name + "/turnOff")
        self.client.subscribe(self.name + "/modeUpdate")

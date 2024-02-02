import math
import threading
import time
import json
from datetime import datetime, timedelta

import paho.mqtt.client as mqtt
import random

from SmartDevice import SmartDevice


class WashingMachine(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.info_topic = name + "/info"
        self.powerState = 0
        self.energy_spending = 0
        self.send_wm_tick_thread = None
        self.is_wm_thread_running = False
        self.mode = ""
        self.wm_topic = name + "/wm"

    def on_message(self, client, userdata, message):
        print(message.topic)
        if message.topic == self.name + "/receive":
            super().on_message(client, userdata, message)

        if message.topic == self.name + "/info":
            print("Ovdeeee samm")
            wm_info = message.payload.decode("utf-8")
            self.energy_spending = float(wm_info)/60000
            self.start_sent_wm_tick_thread()
        elif message.topic == self.name + "/turnOn":
            self.powerState = 1
            print("Turning on")
        elif message.topic == self.name + "/turnOff":
            self.powerState = 0
            self.mode = ""
            print("Turning off")
        elif message.topic == self.name + "/modeChange":
            mode = message.payload.decode("utf-8")
            print(mode)
            self.mode = mode

    def start_sent_wm_tick_thread(self):
        if not self.is_wm_thread_running:
            self.is_wm_thread_running = True
            self.send_wm_tick_thread = threading.Thread(target=self.send_wm_info)
            self.send_wm_tick_thread.start()

    def send_wm_info(self):
        while self.is_wm_thread_running:
            print("publishing on topic: ", self.wm_topic)
            self.client.publish(self.wm_topic, f"{self.mode}, {self.powerState}")
            time.sleep(10)

    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        self.client.subscribe(self.info_topic)
        self.client.subscribe(self.name + "/turnOn")
        self.client.subscribe(self.name + "/turnOff")
        self.client.subscribe(self.name + "/modeChange")

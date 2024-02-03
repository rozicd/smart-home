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
        self.check_scheduled_modes_thread = None
        self.mode = ""
        self.wm_topic = name + "/wm"
        self.sch_modes = []

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
        elif message.topic == self.name + "/schedule":
            sch_modes = message.payload.decode("utf-8")
            print(sch_modes)
            self.sch_modes = json.loads(sch_modes)

    def start_sent_wm_tick_thread(self):
        if not self.is_wm_thread_running:
            self.is_wm_thread_running = True
            self.send_wm_tick_thread = threading.Thread(target=self.send_wm_info)
            self.send_wm_tick_thread.start()
            self.check_scheduled_modes_thread = threading.Thread(target=self.check_for_scheduled_mode)
            self.check_scheduled_modes_thread.start()

    from datetime import datetime, timedelta

    def check_for_scheduled_mode(self):
        while self.is_wm_thread_running:
            current_datetime = datetime.now().replace(microsecond=0)
            new_current_datetime = datetime.now().replace(microsecond=0)

            for scheduled_mode in self.sch_modes:
                start_time_str = scheduled_mode["DateTime"]
                start_time = datetime.strptime(start_time_str, "%Y-%m-%dT%H:%M:%S")
                end_time = start_time + timedelta(seconds=10)

                if start_time == current_datetime:
                    print("usao")
                    self.powerState = 1
                    self.mode = scheduled_mode["Mode"]

                if end_time == new_current_datetime:
                    self.powerState = 0
                    self.mode = ""

    def send_wm_info(self):
        while self.is_wm_thread_running:
            print("publishing on topic: ", self.wm_topic)
            self.client.publish(self.wm_topic, f"{self.mode}, {self.powerState}")
            time.sleep(5)

    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        self.client.subscribe(self.info_topic)
        self.client.subscribe(self.name + "/turnOn")
        self.client.subscribe(self.name + "/turnOff")
        self.client.subscribe(self.name + "/modeChange")
        self.client.subscribe(self.name + "/schedule")

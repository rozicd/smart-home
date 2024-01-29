import math
import threading
import time
import json
from datetime import datetime, timedelta

import paho.mqtt.client as mqtt
import random

from SmartDevice import SmartDevice


def get_ac_mode(ac_mode):
    if ac_mode == 0:
        return "COOLING"
    elif ac_mode == 1:
        return "HEATING"
    elif ac_mode == 3:
        return "FAN"


class AirConditioner(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.ac_info_topic = name + "/info"
        self.ac_current_temperature = 20
        self.powerState = 0
        self.ac_mode = ""
        self.energy_spending = 0
        self.send_ac_tick_thread = None
        self.is_send_ac_thread_running = False
        self.send_ac_energy_thread = None
        self.is_send_ac_energy_running = False
        self.check_scheduled_modes_thread = None
        self.topic_ac = name + "/ac"
        self.schedule_modes = []

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
            ac_info_elements = ac_info.split(',')
            current_temperature = ac_info_elements[0].strip()
            mode = ac_info_elements[1].strip()
            schedule_modes = ','.join(ac_info_elements[2:]).strip()
            json_schedule_modes = json.loads(schedule_modes)
            self.ac_mode = mode
            self.ac_current_temperature = current_temperature
            self.schedule_modes = json_schedule_modes
            print(self.schedule_modes)
            print(self.ac_mode)
        elif msg.topic == self.name + "/schedule":
            sch_modes = msg.payload.decode("utf-8")
            print(sch_modes)
            self.schedule_modes = json.loads(sch_modes)

    def start_send_ac_tick_thread(self):
        if not self.is_send_ac_thread_running:
            self.is_send_ac_thread_running = True
            self.send_ac_tick_thread = threading.Thread(target=self.send_ac_info)
            self.send_ac_tick_thread.start()
            self.check_scheduled_modes_thread = threading.Thread(target=self.check_for_scheduled_mode)
            self.check_scheduled_modes_thread.start()

    def send_ac_info(self):
        while self.is_send_ac_thread_running:
            print(self.topic_ac)
            self.client.publish(self.topic_ac, f"{self.ac_current_temperature}, {self.powerState}, {self.ac_mode}")
            time.sleep(30)

    def check_for_scheduled_mode(self):
        while self.is_send_ac_thread_running:
            print("Krenula provera")
            current_time = datetime.now().time()
            for scheduled_mode in self.schedule_modes:
                start_time_str = scheduled_mode["Start"]
                end_time_str = scheduled_mode["End"]
                start_time = datetime.strptime(start_time_str, "%Y-%m-%dT%H:%M:%S").time()
                end_time = datetime.strptime(end_time_str, "%Y-%m-%dT%H:%M:%S").time()

                current_time = current_time.replace(second=0, microsecond=0)
                if start_time == current_time:
                    print("PALIM SCHEDULED")
                    self.ac_mode = get_ac_mode(scheduled_mode['ACMode'])
                    self.ac_current_temperature = scheduled_mode['Temeprature']
                    self.powerState = 1
                elif end_time == current_time:
                    print("GASIM SCHEDULED")
                    self.powerState = 0
            time.sleep(10)

    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        print("AC SUBSCRIBED")
        self.client.subscribe(self.ac_info_topic)
        self.client.subscribe(self.name + "/turnOn")
        self.client.subscribe(self.name + "/turnOff")
        self.client.subscribe(self.name + "/modeChange")
        self.client.subscribe(self.name + "/schedule")

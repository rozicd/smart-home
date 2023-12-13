import math
import threading
import time
from datetime import datetime

import paho.mqtt.client as mqtt
import random

from simulations.SmartDevice import SmartDevice


class Lamp(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.lamp_info_topic = name+"/info"
        self.light_strength = 0
        self.light_threshold = 50
        self.power_state = 0
        self.auto_mode = True
        self.amplitude = 50
        self.period = 24 * 60
        self.topicLight = name+"/light"
        self.send_lamp_tick_thread = None
        self.is_send_lamp_thread_running = False
        self.offset = 0
    def on_message(self, client, userdata, msg):
        if msg.topic == self.name + "/recive":
            super().on_message(client, userdata, msg)
        command = msg.payload.decode('utf-8')
        if msg.topic == self.name + "/info":
            lampInfo = msg.payload.decode('utf-8')
            light_treshold, mode = lampInfo.split(',')
            self.light_threshold = int(light_treshold)
            if mode == "MANUAL":
                self.auto_mode = False
            else:
                self.auto_mode = True
            print(f"Light threshold set to {self.light_threshold}")
            print(f"Auto mode set to {self.auto_mode}")
            self.start_send_lamp_tick_thread()
        elif msg.topic == self.name + "/turnOn":
            if self.auto_mode is False:
                self.power_state = 1
            print("Turning ON the lamp")

        elif msg.topic == self.name + "/turnOff":
            if self.auto_mode is False:
                self.power_state = 0
            print("Turning OFF the lamp")

        elif msg.topic == self.name + "/thresholdUpdate":
            lampInfo = msg.payload.decode('utf-8')
            light_treshold, mode = lampInfo.split(',')
            self.light_threshold = int(light_treshold)
            print("Updating threshold")

        elif msg.topic == self.name + "/modeUpdate":
            lampInfo = msg.payload.decode('utf-8')
            light_treshold, mode = lampInfo.split(',')
            if mode == "MANUAL":
                self.auto_mode = False
            else:
                self.auto_mode = True
            print("Updating mode")

    def start_send_lamp_tick_thread(self):
        if not self.is_send_lamp_thread_running:
            print("RUNNING THREAD")
            self.is_send_lamp_thread_running = True
            self.send_lamp_tick_thread = threading.Thread(target=self.sendLampInfo)
            self.send_lamp_tick_thread.start()

    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        self.client.subscribe(self.lamp_info_topic)
        self.client.subscribe(self.name + "/turnOn")
        self.client.subscribe(self.name + "/turnOff")
        self.client.subscribe(self.name + "/thresholdUpdate")
        self.client.subscribe(self.name + "/modeUpdate")

        print(f"Subscribed to topic: {self.lamp_info_topic}")

    def sendLampInfo(self):
        while self.is_send_lamp_thread_running:
            now = datetime.now()
            minutes_since_midnight = now.hour * 60 + now.minute

            sine_value = self.amplitude * math.sin(
                2 * math.pi * (minutes_since_midnight + self.offset) / self.period)

            adjusted_value = max(0, min(100, sine_value + self.amplitude))

            self.light_strength = adjusted_value
            if self.auto_mode:
                if self.light_strength < self.light_threshold and self.power_state == 0:
                    self.turn_on()
                elif self.light_strength >= self.light_threshold and self.power_state == 1:
                    self.turn_off()
            print(self.light_strength)
            self.client.publish(self.topicLight, f"{self.light_strength},{self.power_state}")

            time.sleep(10)
        self.is_send_lamp_thread_running = False

    def turn_on(self):
        self.power_state = 1

    def turn_off(self):
        self.power_state = 0
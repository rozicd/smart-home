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
            if self.send_lamp_tick_thread is None or not self.send_lamp_tick_thread.is_alive():
                self.send_lamp_tick_thread = threading.Thread(target=self.sendLampInfo)
                self.send_lamp_tick_thread.start()


    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        self.client.subscribe(self.lamp_info_topic)
        print(f"Subscribed to topic: {self.lamp_info_topic}")

    def sendLampInfo(self):
        while self.running:
            if self.auto_mode:
                now = datetime.now()
                minutes_since_midnight = now.hour * 60 + now.minute

                sine_value = self.amplitude * math.sin(
                    2 * math.pi * (minutes_since_midnight + self.offset) / self.period)

                adjusted_value = max(0, min(100, sine_value + self.amplitude))

                self.light_strength = adjusted_value
                if self.light_strength < self.light_threshold and self.power_state == 0:
                    self.turn_on()
                elif self.light_strength >= self.light_threshold and self.power_state == 1:
                    self.turn_off()
            print(self.light_strength)
            self.client.publish(self.topicLight, f"{self.light_strength},{self.power_state}")

            time.sleep(10)

    def turn_on(self):
        self.power_state = 1

    def turn_off(self):
        self.power_state = 0
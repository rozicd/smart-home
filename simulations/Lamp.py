import threading
import time
import paho.mqtt.client as mqtt
import random

from simulations.SmartDevice import SmartDevice


class Lamp(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.light_strength = 0
        self.light_threshold = 50
        self.power_state = 'off'
        self.auto_mode = True

    def on_message(self, client, userdata, msg):
        super().on_message(client, userdata, msg)

        command = msg.payload.decode('utf-8')
        if command == "SetThreshold":
            try:
                self.light_threshold = int(msg.topic.split("/")[-1])
                print(f"Light threshold set to {self.light_threshold}")
            except ValueError:
                print("Invalid threshold value")

    def sendStatus(self):
        while self.running:
            if self.auto_mode:
                self.light_strength = random.randint(0, 100)
                print(f"Light strength: {self.light_strength}")

                if self.light_strength < self.light_threshold and self.power_state == 'off':
                    self.turn_on()
                elif self.light_strength >= self.light_threshold and self.power_state == 'on':
                    self.turn_off()

            super().sendStatus()
            time.sleep(10)

    def turn_on(self):
        self.client.publish(self.topicSend, f"{self.name} : Turning on the light")
        self.power_state = 'on'

    def turn_off(self):
        self.client.publish(self.topicSend, f"{self.name} : Turning off the light")
        self.power_state = 'off'
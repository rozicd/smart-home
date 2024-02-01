import math
import threading
import time
from datetime import datetime
import ephem

import paho.mqtt.client as mqtt
import random

from SmartDevice import SmartDevice


class Lamp(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.latitude = 44.786568
        self.longitude = 20.448921
        self.lamp_info_topic = name+"/info"
        self.light_strength = 0
        self.light_threshold = 50
        self.power_state = 0
        self.auto_mode = True
        self.amplitude = 120
        self.period = 24 * 60
        self.energy_spending = 0
        self.topicLight = name+"/light"
        self.send_lamp_tick_thread = None
        self.is_send_lamp_thread_running = False
        self.send_lamp_energy_thread = None
        self.is_send_lamp_energy_running = False
        self.offset = 0
    def on_message(self, client, userdata, msg):
        if msg.topic == self.name + "/recive":
            super().on_message(client, userdata, msg)
        command = msg.payload.decode('utf-8')
        if msg.topic == self.name + "/info":
            lampInfo = msg.payload.decode('utf-8')
            light_treshold, mode,energy_spending = lampInfo.split(',')
            self.light_threshold = int(light_treshold)
            self.energy_spending = float(energy_spending)/60000
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
            self.send_lamp_energy_thread = threading.Thread(target=self.sendEnergySpending)
            self.send_lamp_energy_thread.start()

    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        self.client.subscribe(self.lamp_info_topic)
        self.client.subscribe(self.name + "/turnOn")
        self.client.subscribe(self.name + "/turnOff")
        self.client.subscribe(self.name + "/thresholdUpdate")
        self.client.subscribe(self.name + "/modeUpdate")

        print(f"Subscribed to topic: {self.lamp_info_topic}")

    def sendEnergySpending(self):
        while self.is_send_lamp_thread_running:
            self.client.publish(self.name +"/spending", f"{self.energy_spending}")
            time.sleep(60)

    def calculate_solar_elevation(self, observer, date_time):
        sun = ephem._sun
        observer.date = date_time.strftime('%Y-%m-%d %H:%M:%S')
        sun.compute(observer)
        solar_elevation = math.degrees(sun.alt)
        return solar_elevation

    def solar_elevation_to_lux(self, solar_elevation):
        print(solar_elevation)
        lux = max(0, math.sin(math.radians(solar_elevation)))
        return lux
    def sendLampInfo(self):
        observer = ephem.Observer()
        observer.lat = str(self.latitude)
        observer.lon = str(self.longitude)
        while self.is_send_lamp_thread_running:
            now = datetime.now()
            solar_elevation = self.calculate_solar_elevation(observer, now)
            lux_value = self.solar_elevation_to_lux(solar_elevation)


            normalized_solar_elevation = (lux_value) * 150

            adjusted_value = max(0, normalized_solar_elevation)

            self.light_strength = adjusted_value
            if self.auto_mode:
                if self.light_strength < self.light_threshold and self.power_state == 0:
                    self.turn_on()
                elif self.light_strength >= self.light_threshold and self.power_state == 1:
                    self.turn_off()
            print(self.light_strength)
            print(self.power_state)
            print(self.light_threshold)
            self.client.publish(self.topicLight, f"{self.light_strength},{self.power_state}")


            time.sleep(10)
        self.is_send_lamp_thread_running = False

    def turn_on(self):
        self.power_state = 1

    def turn_off(self):
        self.power_state = 0
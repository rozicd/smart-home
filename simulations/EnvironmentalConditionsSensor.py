import math
import random
import threading
import time
import paho.mqtt.client as mqtt
from SmartDevice import SmartDevice


class EnvironmentalConditionsSensor(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.sensor_info_topic = name + "/info"
        self.air_humidity = 0
        self.room_temperature = 0
        self.topic_sensor = name + "/environmentalConditionsSensor"
        self.send_sensor_tick_thread = None
        self.send_sensor_energy_thread = None
        self.is_send_sensor_thread_running = False
        self.energy_spending = 0

    def on_message(self, client, userdata, msg):
        if msg.topic == self.name + "/recive":
            super().on_message(client, userdata, msg)

        if msg.topic == self.name + "/info":
            sensorInfo = msg.payload.decode('utf-8')
            power_consumption, room_temperature, air_humidity = sensorInfo.split(',')
            self.energy_spending = float(power_consumption)/60000
            print(f"Power consumption: {power_consumption}")
            print(f"Room temperature: {room_temperature}")
            print(f"Air humidity: {air_humidity}")
            self.start_send_sensor_tick_thread()

    def start_send_sensor_tick_thread(self):
        if not self.is_send_sensor_thread_running:
            print("RUNNING THREAD")
            self.is_send_sensor_thread_running = True
            self.send_sensor_tick_thread = threading.Thread(target=self.send_sensor_info)
            self.send_sensor_tick_thread.start()
            self.send_sensor_energy_thread = threading.Thread(target=self.sendEnergySpending)
            self.send_sensor_energy_thread.start()

    def sendEnergySpending(self):
        while self.is_send_sensor_thread_running:
            self.client.publish(self.name +"/spending", f"{self.energy_spending}")
            time.sleep(60)
    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        print("ECS subscribed")
        self.client.subscribe(self.sensor_info_topic)

    def send_sensor_info(self):
        while self.is_send_sensor_thread_running:
            room_temperature = random.randint(19, 23)
            air_humidity = random.randint(10, 15)
            self.room_temperature = room_temperature
            self.air_humidity = air_humidity
            self.client.publish(self.topic_sensor, f"{self.air_humidity},{self.room_temperature}")
            time.sleep(10)
        self.is_send_sensor_thread_running = False
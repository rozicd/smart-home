import threading
import time
import paho.mqtt.client as mqtt
import random

class ECS:
    def __init__(self,name):
        self.broker_address = "localhost"
        self.broker_port = 8883
        self.topicSend = name+"/status"
        self.topicRecive = name+"/recive"
        self.status = 'offline'
        self.name = name

        self.client = mqtt.Client()
        self.client.on_connect = self.on_connect
        self.client.on_message = self.on_message
        self.send_status_thread = threading.Thread(target=self.sendStatus)
        self.running = False  # Shared variable to control the thread

        self.client.connect(self.broker_address, self.broker_port, 60)

    def on_connect(self, client, userdata, flags, rc):
        print(f"Connected with result code {rc}")
        self.client.subscribe(self.topicRecive)
        print(f"Subscribed to topic: {self.topicRecive}")

    def on_message(self, client, userdata, msg):
        command = msg.payload.decode('utf-8')
        print(command)
        if command == "PowerOn":
            self.status = 'online'
            print(self.status)
            if not self.send_status_thread.is_alive():
                self.running = True  # Set the shared variable to True
                self.send_status_thread = threading.Thread(target=self.sendStatus)
                self.send_status_thread.start()

        if command == "PowerOff":
            self.running = False  # Set the shared variable to False
            if self.send_status_thread.is_alive():
                self.send_status_thread.join()

    def run(self):
        self.client.loop_start() 
        while True:
            pass

    def sendStatus(self):
        while self.running:
            random_number = random.uniform(1.1, 0.9)
            print("Publishing message")
            self.client.publish(self.topicSend, f"{self.name} : online")
            self.client.publish(self.topicSend, f"{self.name} : Temperature: {21*random_number}°C")
            time.sleep(10)



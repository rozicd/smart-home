import threading
import time
import paho.mqtt.client as mqtt
import random

class SmartDevice:
    def __init__(self,name):
        self.broker_address = "localhost"
        self.broker_port = 8883
        self.topicSend = name + "/status"
        self.topicRecive = name + "/recive"
        self.status = 'offline'
        self.name = name

        self.client = mqtt.Client()
        self.client.on_connect = self.on_connect
        self.client.on_message = self.on_message
        self.send_status_thread = threading.Thread(target=self.sendStatus)
        self.running = True
        self.client.will_set(self.topicSend, payload=f"{self.name} : offline", qos=2, retain=True)

        self.client.connect(self.broker_address, self.broker_port, 60)



    def on_connect(self, client, userdata, flags, rc):
        print(f"Connected with result code {rc}")
        self.client.subscribe(self.topicRecive)
        print(f"Subscribed to topic: {self.topicRecive}")

    def on_message(self, client, userdata, msg):
        command = msg.payload.decode('utf-8')

        if command == "PowerOn":
            self.status = 'online'
            print(self.status)
            if not self.send_status_thread.is_alive():
                self.running = True
                self.send_status_thread = threading.Thread(target=self.sendStatus)
                self.send_status_thread.start()

        if command == "PowerOff":
            if self.send_status_thread.is_alive():
                self.send_status_thread.join()

    def run(self):
        self.client.loop_start()
        while True:
            pass

    def sendStatus(self):
        while self.running:
            print("Publishing message from",self.topicSend)
            self.client.publish(self.topicSend, f"{self.name} : online")
            time.sleep(10)

if __name__ == "__main__":
    smart = SmartDevice("smart")
    smart.run()
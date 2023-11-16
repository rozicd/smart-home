import time
import paho.mqtt.client as mqtt

class SmartDevice:
    def __init__(self):
        self.broker_address = "localhost"
        self.broker_port = 8883
        self.topicSend = "smart_device/status"
        self.topicRecive = "smart_device/recive"

        self.client = mqtt.Client()
        self.client.on_connect = self.on_connect
        self.client.on_message = self.on_message

        self.client.connect(self.broker_address, self.broker_port, 60)

    def on_connect(self, client, userdata, flags, rc):
        print(f"Connected with result code {rc}")
        self.client.subscribe(self.topicRecive)
        print(f"Subscribed to topic: {self.topicRecive}")

    def on_message(self, client, userdata, msg):
        print(f"Received message on topic {msg.topicRecive}: {msg.payload.decode('utf-8')}")

    def run(self):
        self.client.loop_start()  # Start the loop to handle callbacks

        while True:
            print("Publishing message")
            self.client.publish(self.topicSend, "Device online")
            time.sleep(10)

if __name__ == "__main__":
    smart_device = SmartDevice()
    smart_device.run()

import threading
import time
import paho.mqtt.client as mqtt
import random
from SmartDevice import SmartDevice
class ESC(SmartDevice) :

    def sendStatus(self):
        while self.running:
            print("Publishing message")
            self.client.publish(self.topicSend, f"{self.name} : online")
            self.client.publish(self.topicSend, f"{self.name} : xd")

            time.sleep(10)

if __name__ == "__main__":
    esc = ESC("test")
    esc.run()

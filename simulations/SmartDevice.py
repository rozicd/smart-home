import threading
import time
import paho.mqtt.client as mqtt
import random

class SmartDevice:
    def __init__(self,name):
       
        self.name = name


    def run(self):
        self.sendStatus()
        while True:
            pass

    def sendStatus(self):
        while self.running:
            print(self.name"-online")
            time.sleep(5)




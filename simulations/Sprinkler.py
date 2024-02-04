import threading
import time
from datetime import datetime, time as dt_time, timedelta

import paho.mqtt.client as mqtt
from SmartDevice import SmartDevice

class Sprinkler(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.sprinkler_info_topic = name + "/info"
        self.power = False
        self.schedules = {}
        self.sprinkler_thread = None
        self.schedule_thread = None
        self.energy_spending = 0
        self.send_lamp_energy_thread = None
        self.is_send_lamp_energy_running = False
    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        self.client.subscribe(self.name + "/info")
        self.client.subscribe(self.name + "/turnOn")
        self.client.subscribe(self.name + "/turnOff")
        self.client.subscribe(self.name + "/setSchedules")

    def on_message(self, client, userdata, msg):
        super().on_message(client, userdata, msg)
        command = msg.payload.decode('utf-8')

        if msg.topic == self.name + "/info":
            print("SPRINKLER INFOOOO")
            print(command)
            sprinkler_info = command.split(',')
            self.power = sprinkler_info[0] == "True"
            self.energy_spending = float(sprinkler_info[1])/60000
            if sprinkler_info[2] != "":
                self.schedules = self.parse_schedules(sprinkler_info[2:])
            else:
                self.schedules = {}
            print("SPRINKLEEEEER")
            print(f"Power: {self.power}")
            print(f"Energy: {self.energy_spending}")
            print(f"Schedules: {self.schedules}")

            if self.sprinkler_thread is None:
                print("SPRINKLER")
                self.sprinkler_thread = threading.Thread(target=self.run_sprinkler)
                self.sprinkler_thread.daemon = True
                self.sprinkler_thread.start()
                self.send_lamp_energy_thread = threading.Thread(target=self.sendEnergySpending)
                self.send_lamp_energy_thread.start()

            if self.schedule_thread is None:
                print("SCHEDULE")
                self.schedule_thread = threading.Thread(target=self.run_schedule)
                self.schedule_thread.daemon = True
                self.schedule_thread.start()

        elif msg.topic == self.name + "/turnOn":
            print("ONNN")
            self.client.publish(self.name + "/action", f"{command},1")
            self.power = True

        elif msg.topic == self.name + "/turnOff":
            print("OFF")
            self.client.publish(self.name + "/action", f"{command},2")
            self.power = False

        elif msg.topic == self.name + "/setSchedules":
            print(command)
            if command == "":
                self.schedules = {}
            else:
                self.schedules = self.parse_schedules(command.split(','))

    def parse_schedules(self, schedule_data):
        print(schedule_data)
        schedules = {}
        for schedule_str in schedule_data:
            schedule_parts = schedule_str.split(':-:')
            schedule_id = schedule_parts[0]
            start_time = datetime.strptime(schedule_parts[1], "%m/%d/%Y %I:%M:%S %p")
            duration = int(schedule_parts[2])
            end_time = start_time + timedelta(minutes=duration)

            if start_time not in schedules:
                schedules[start_time] = (schedule_id, True)

            if end_time not in schedules:
                schedules[end_time] = (schedule_id, False)

        return schedules

    def sendEnergySpending(self):
        while self.send_lamp_energy_thread:
            self.client.publish(self.name +"/spending", f"{self.energy_spending}")
            time.sleep(60)
    def run_sprinkler(self):
        while True:

            if self.power:
                self.client.publish(self.name + "/powerState", 1)
            else:
                self.client.publish(self.name + "/powerState", 0)

            time.sleep(5)

    def run_schedule(self):
        while True:
            current_time = datetime.now()
            for schedule_time, (schedule_id, action) in list(self.schedules.items()):
                if schedule_time <= current_time:
                    print("SCHEDULEEEEEE")
                    print(schedule_time, (schedule_id, action))
                    if action:
                        self.power = True
                        self.client.publish(self.name + "/powerState", 1)
                        self.client.publish(self.name + "/action", f"System,1")
                    else:
                        self.power = False
                        self.client.publish(self.name + "/powerState", 0)
                        self.client.publish(self.name + "/action", f"System,2")
                        print("CLEARING SCHEDULE",schedule_id)
                        self.client.publish(self.name + "/clearSchedule",f"{schedule_id}")
                    del self.schedules[schedule_time]

            time.sleep(5)

    def is_within_schedule(self, current_time, start_time, end_time):
        current_minutes = current_time.minute + current_time.hour * 60
        start_minutes = start_time.hour * 60 + start_time.minute
        end_minutes = end_time.hour * 60 + end_time.minute

        return start_minutes <= current_minutes <= end_minutes

if __name__ == "__main__":
    sprinkler_system = SprinklerSystem("SprinklerSystem")
    try:
        sprinkler_system.sprinkler_thread.start()
        sprinkler_system.schedule_thread.start()
        sprinkler_system.run()
    except KeyboardInterrupt:
        pass

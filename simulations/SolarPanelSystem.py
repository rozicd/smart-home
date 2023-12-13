from datetime import datetime
import threading
import time
import paho.mqtt.client as mqtt
from SmartDevice import SmartDevice

class SolarPanelSystem(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.panel_info_topic = name+"/info"
        self.number_of_panels = 0
        self.size_per_panel = 0
        self.efficiency = 0
        self.send_power_thread = None
        self.power_topic = name+"/power"


        

    def on_message(self, client, userdata, msg):
        if msg.topic == self.name +"/recive":
            super().on_message(client, userdata, msg)
            
        if self.running :
            if msg.topic == self.name +"/info":
                spsInfo = msg.payload.decode('utf-8')  
                numberOfPanels, size, efficiency = spsInfo.split(',')
                self.number_of_panels = float(numberOfPanels)
                self.size_per_panel = float(size)
                self.efficiency = float(efficiency)/1000
                if self.send_power_thread is None or not self.send_power_thread.is_alive():
                    self.send_power_thread = threading.Thread(target=self.sendEnergyPerMinute)
                    self.send_power_thread.start()

    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        self.client.subscribe(self.panel_info_topic)
        print(f"Subscribed to topic: {self.panel_info_topic}")

    def calculate_sun_hours(self,current_month, current_hour):

    
        daylight_hours = {
            1: 7, 2: 7.5, 3: 8, 4: 9, 5: 10, 6: 11,
            7: 11, 8: 10, 9: 9, 10: 8, 11: 7.5, 12: 7
        }

        return daylight_hours.get(current_month, 4) * (1 - abs((current_hour - 12) / 12))

    def calculate_energy_production(self):
        current_time = datetime.now().time()
        current_month = datetime.now().month
        current_hour = current_time.hour
        minutes_per_hour = 60

        # Calculate energy production per day in kilowatt-hours (kWh)
        sun_hours_per_day = self.calculate_sun_hours(current_month, current_hour)
        energy_per_day = (
            self.size_per_panel * 1000 * self.efficiency * sun_hours_per_day
        ) / 1000

        # Calculate energy production per minute
        energy_per_minute = energy_per_day / (24 * minutes_per_hour)

        # Calculate total energy production for the given number of panels
        total_energy_per_minute = energy_per_minute * self.number_of_panels

        return total_energy_per_minute
    
    def sendEnergyPerMinute(self):
        while self.running:
            power = str(self.calculate_energy_production())
            print(power)
            self.client.publish(self.power_topic, power)
            time.sleep(10)
        self.client.publish(self.power_topic, "disconnected")
        return



if __name__ == "__main__":
    solar_panel_system = SolarPanelSystem("test")
    solar_panel_system.run()

import threading
import time
from random import random, randint, choice

import paho.mqtt.client as mqtt
from SmartDevice import SmartDevice

class CarGate(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.gate_info_topic = name + "/info"
        self.mode = False
        self.gate_status = "CLOSED"
        self.allowed_vehicles = set()
        self.inside_vehicles = set()

        self.simulation_thread = None

    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        self.client.subscribe(self.name + "/info")
        self.client.subscribe(self.name + "/openGate")
        self.client.subscribe(self.name + "/closeGate")
        self.client.subscribe(self.name + "/setMode")
        self.client.subscribe(self.name + "/setAllowedVehicles")

    def on_message(self, client, userdata, msg):
        super().on_message(client, userdata, msg)
        command = msg.payload.decode('utf-8')

        if msg.topic == self.name + "/info":
            gate_info = command.split(',')
            self.mode = gate_info[0]
            self.gate_status = "CLOSED"
            self.allowed_vehicles = set(gate_info[2:])
            if len(self.allowed_vehicles):
                self.allowed_vehicles = set()
            print(f"Mode: {self.mode}")
            print(f"Gate Status: {self.gate_status}")
            print(f"Allowed Vehicles: {self.allowed_vehicles}")

            if self.simulation_thread is None:
                self.simulation_thread = threading.Thread(target=self.simulate_vehicles)
                self.simulation_thread.daemon = True
                self.simulation_thread.start()

        elif msg.topic == self.name + "/openGate":
            self.client.publish(self.name + "/action", f"{command},3")
            self.handle_gate_open()

        elif msg.topic == self.name + "/closeGate":
            self.client.publish(self.name + "/action", f"{command},4")
            self.handle_gate_close()

        elif msg.topic == self.name + "/setMode":
            self.set_mode(command)

        elif msg.topic == self.name + "/setAllowedVehicles":
            if command == "":
                self.set_allowed_vehicles(set())
            else:
                self.set_allowed_vehicles(command.split(','))


    def set_mode(self, mode):
        self.mode = mode
        print(f"Mode set to {self.mode}")


    def set_allowed_vehicles(self, vehicles):
        self.allowed_vehicles = set(vehicles)
        print(f"Allowed Vehicles set to {self.allowed_vehicles}")

    def simulate_vehicles(self):
        while True:
            time.sleep(10)
            print("DOING CAR")
            if choice([True, False]):
                print(self.gate_status)
                print(self.mode)
                generated_plate = self.generate_license_plate()
                allowed_list = self.allowed_vehicles.copy()

                if len(self.allowed_vehicles) == 0:
                    license_plate = generated_plate
                else:
                    allowed_list.add(generated_plate)
                    license_plate = choice(list(allowed_list))
                self.handle_gate_entry(license_plate)
            elif self.inside_vehicles:
                license_plate = choice(list(self.inside_vehicles))
                self.handle_vehicle_exit(license_plate)

    def generate_license_plate(self):
        letters = ''.join([chr(randint(ord('A'), ord('Z'))) for _ in range(2)])
        letters2 = ''.join([chr(randint(ord('A'), ord('Z'))) for _ in range(2)])
        numbers = ''.join([str(randint(0, 9)) for _ in range(3)])
        print( f"{letters}-{numbers}-{letters2}")
        return f"{letters}-{numbers}-{letters2}"

    def handle_gate_entry(self, license_plate):
        if self.gate_status == "OPEN":
            print("HERE34")
            self.record_vehicle_entry(license_plate)
        elif self.mode == "PUBLIC" or (self.mode == "PRIVATE" and license_plate in self.allowed_vehicles):
            print("HERE")
            print(self.gate_status)
            self.client.publish(self.name + "/action", "System,3")
            self.handle_gate_open()
            time.sleep(5)
            self.client.publish(self.name + "/action", f"System,4")
            self.handle_gate_close()
            self.record_vehicle_entry(license_plate)

    def handle_gate_open(self):
        if self.gate_status == "CLOSED":
            print("Opening the gate")
            self.gate_status = "OPENING"
            self.client.publish(self.name + "/gateStatus", self.gate_status)
            time.sleep(2)
            self.gate_status = "OPEN"
            self.client.publish(self.name + "/gateStatus", self.gate_status)


    def handle_gate_close(self):
        if self.gate_status == "OPEN":
            print("Closing the gate")
            self.gate_status = "CLOSING"
            self.client.publish(self.name + "/gateStatus", self.gate_status)
            time.sleep(2)
            self.gate_status = "CLOSED"
            self.client.publish(self.name + "/gateStatus", self.gate_status)

    def handle_vehicle_exit(self, license_plate):
        if self.gate_status == "OPEN":
            print("HERE33")
            self.record_vehicle_exit(license_plate)
        else:
            print("HERE")
            print(self.gate_status)
            self.client.publish(self.name + "/action", "System,3")
            self.handle_gate_open()
            time.sleep(5)
            self.client.publish(self.name + "/action", "System,4")
            self.handle_gate_close()
            self.record_vehicle_exit(license_plate)

    def record_vehicle_entry(self, license_plate):
        print(f"Recording vehicle entry - License Plate: {license_plate}")
        self.client.publish(self.name + "/action", f"{license_plate},1")

        self.inside_vehicles.add(license_plate)

    def record_vehicle_exit(self, license_plate):
        print(f"Recording vehicle exit - License Plate: {license_plate}")
        self.client.publish(self.name + "/action", f"{license_plate},2")
        self.inside_vehicles.remove(license_plate)

if __name__ == "__main__":
    car_gate = CarGate("CarGate")
    try:
        car_gate.simulation_thread.start()
        car_gate.run()
    except KeyboardInterrupt:
        pass

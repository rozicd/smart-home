import threading
import time
from random import random

import paho.mqtt.client as mqtt
from simulations.SmartDevice import SmartDevice

class CarGate(SmartDevice):
    def __init__(self, name):
        super().__init__(name)
        self.gate_info_topic = name + "/info"
        self.gate_status = "closed"
        self.public_mode = False
        self.private_mode = False
        self.allowed_vehicles = set()
        self.inside_vehicles = set()
        self.camera_reading = None
        self.proximity_sensor = False

        self.entering_thread = None
        self.exiting_thread = None

        self.entering_lock = threading.Lock()
        self.exiting_lock = threading.Lock()

        self.simulation_thread = threading.Thread(target=self.simulate_vehicles)
        self.simulation_thread.daemon = True  # Set as a daemon thread to terminate with the main thread

    def on_connect(self, client, userdata, flags, rc):
        super().on_connect(client, userdata, flags, rc)
        self.client.subscribe(self.name + "/openGate")
        self.client.subscribe(self.name + "/closeGate")
        self.client.subscribe(self.name + "/setPublicMode")
        self.client.subscribe(self.name + "/setPrivateMode")
        self.client.subscribe(self.name + "/setAllowedVehicles")
        self.client.subscribe(self.name + "/setCameraReading")
        self.client.subscribe(self.name + "/setProximitySensor")

    def on_message(self, client, userdata, msg):
        super().on_message(client, userdata, msg)
        command = msg.payload.decode('utf-8')

        if msg.topic == self.name + "/info":
            gate_info = command.split(',')
            self.public_mode = gate_info[0] == "True"
            self.private_mode = gate_info[1] == "True"
            self.allowed_vehicles = set(gate_info[2:])
            print(f"Public Mode: {self.public_mode}")
            print(f"Private Mode: {self.private_mode}")
            print(f"Allowed Vehicles: {self.allowed_vehicles}")

            if self.entering_thread is None:
                self.entering_thread = threading.Thread(target=self.simulate_entering_vehicles)
                self.entering_thread.daemon = True
                self.entering_thread.start()

            if self.exiting_thread is None:
                self.exiting_thread = threading.Thread(target=self.simulate_exiting_vehicles)
                self.exiting_thread.daemon = True
                self.exiting_thread.start()

        elif msg.topic == self.name + "/openGate":
            self.handle_gate_open()

        elif msg.topic == self.name + "/closeGate":
            self.handle_gate_close()

        elif msg.topic == self.name + "/setPublicMode":
            self.set_public_mode(command)

        elif msg.topic == self.name + "/setPrivateMode":
            self.set_private_mode(command)

        elif msg.topic == self.name + "/setAllowedVehicles":
            self.set_allowed_vehicles(command.split(','))


    def set_public_mode(self, mode):
        self.public_mode = mode == "True"
        print(f"Public Mode set to {self.public_mode}")

    def set_private_mode(self, mode):
        self.private_mode = mode == "True"
        print(f"Private Mode set to {self.private_mode}")

    def set_allowed_vehicles(self, vehicles):
        self.allowed_vehicles = set(vehicles)
        print(f"Allowed Vehicles set to {self.allowed_vehicles}")


    def simulate_entering_vehicles(self):
        while True:
            with self.entering_lock:
                new_license_plate = self.generate_license_plate()
                print(f"Vehicle with license plate {new_license_plate} approaching the gate (Entering).")

                if self.proximity_sensor:
                    if new_license_plate in self.inside_vehicles:
                        self.handle_vehicle_exit(new_license_plate)
                    else:
                        self.handle_gate_entry(new_license_plate)
                else:
                    print("Proximity sensor is disabled. Unable to simulate gate operation.")

                time.sleep(60)

    def simulate_exiting_vehicles(self):
        while True:
            with self.exiting_lock:
                time.sleep(60)
                license_plate_to_exit = random.choice(list(self.inside_vehicles))
                print(f"Vehicle with license plate {license_plate_to_exit} leaving the gate (Exiting).")

                self.handle_vehicle_exit(license_plate_to_exit)

    def generate_license_plate(self):
        return ''.join([chr(ord('A') + i) for i in range(3)]) + ''.join([str(random.randint(0, 9)) for _ in range(3)])

    def handle_gate_entry(self, license_plate):
        if self.public_mode or (self.private_mode and license_plate in self.allowed_vehicles):
            self.open_gate()
            time.sleep(5)
            self.handle_gate_close()
            self.record_vehicle_entry(license_plate)
        else:
            self.client.publish(self.name + "/action", f"{license_plate},{2}")

    def handle_gate_open(self):
        print("Opening the gate")
        time.sleep(2)
        self.gate_status = "open"
        self.client.publish(self.name + "/gateStatus", self.gate_status)

    def handle_gate_close(self):
        print("Closing the gate")
        time.sleep(2)
        self.gate_status = "closed"
        self.client.publish(self.name + "/gateStatus", self.gate_status)

    def handle_vehicle_exit(self, license_plate):
        self.open_gate()
        time.sleep(5)
        self.handle_gate_close()
        self.record_vehicle_exit(license_plate)

    def record_vehicle_entry(self, license_plate):
        print(f"Recording vehicle entry - License Plate: {license_plate}")
        self.client.publish(self.name + "/action", f"{license_plate},{0}")

        self.inside_vehicles.add(license_plate)

    def record_vehicle_exit(self, license_plate):
        print(f"Recording vehicle exit - License Plate: {license_plate}")
        self.client.publish(self.name + "/action", f"{license_plate},{1}")
        self.inside_vehicles.remove(license_plate)

if __name__ == "__main__":
    car_gate = CarGate("CarGate")
    try:
        car_gate.simulation_thread.start()
        car_gate.run()
    except KeyboardInterrupt:
        pass

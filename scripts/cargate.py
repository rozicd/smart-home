import time
from random import randint, choice
from datetime import datetime, timedelta
from influxdb_client import InfluxDBClient, Point
from influxdb_client.client.write_api import SYNCHRONOUS

# Declare action_queue globally
action_queue = []
batch = []
batch_length = 100
def handle_gate_open(gate_status,time):
    global action_queue,start_time  # Use the globally defined action_queue
    gate_status = "OPENING"
    gate_status = "OPEN"
    action_queue.append(("System", "Opened Gate",start_time))
    return gate_status

def handle_gate_close(gate_status,time):
    global action_queue,start_time  # Use the globally defined action_queue
    gate_status = "CLOSING"
    gate_status = "CLOSED"
    start_time += timedelta(minutes=1)
    action_queue.append(("System", "Closed Gate",start_time))
    return gate_status

def handle_gate_entry(license_plate, gate_status, mode, allowed_vehicles, time):
    global action_queue,start_time  # Use the globally defined action_queue
    if gate_status == "OPEN":
        time += timedelta(minutes=1)
        action_queue.append((license_plate, "Vehicle entered",start_time))

    elif mode == "PUBLIC" or (mode == "PRIVATE" and license_plate in allowed_vehicles):
        handle_gate_open(gate_status,time)
        start_time += timedelta(minutes=1)
        action_queue.append((license_plate, "Vehicle entered",start_time))
        handle_gate_close(gate_status,time)

def handle_vehicle_exit(license_plate, gate_status, time):
    global action_queue,start_time  # Use the globally defined action_queue
    if gate_status == "OPEN":
        start_time += timedelta(minutes=1)
        action_queue.append((license_plate, "Vehicle exited",start_time))

def record_vehicle_entry(license_plate, car_gate_id,time):
    point = Point("Car actions") \
        .tag("Id", str(car_gate_id)) \
        .field("action", "Vehicle entered") \
        .field("user", license_plate) \
        .time(time, write_precision='ms')

    return point

def record_vehicle_exit(license_plate, car_gate_id,time):
    point = Point("Car actions") \
        .tag("Id", str(car_gate_id)) \
        .field("action", "Vehicle exited") \
        .field("user", license_plate) \
        .time(time, write_precision='ms')

    return point

def record_system_action(action, car_gate_id,time):
    point = Point("Car actions") \
        .tag("Id", str(car_gate_id)) \
        .field("action", action) \
        .field("user", "System") \
        .time(time, write_precision='ms')

    return point

def generate_license_plate():
    letters = ''.join([chr(randint(ord('A'), ord('Z'))) for _ in range(2)])
    letters2 = ''.join([chr(randint(ord('A'), ord('Z'))) for _ in range(2)])
    numbers = ''.join([str(randint(0, 9)) for _ in range(3)])
    return f"{letters}-{numbers}-{letters2}"

def simulate_vehicles(gate_status, mode, allowed_vehicles, start_date, write_api, car_gate_id):
    global action_queue,batch,start_time# Use the globally defined action_queue
    end_date = datetime.utcnow()
    simulation_period = timedelta(days=90)

    while start_time <= end_date:
        current_date = datetime.utcnow()
        time_difference = current_date - start_time
        if choice([True, False]):
            print(start_time)
            generated_plate = generate_license_plate()
            allowed_list = allowed_vehicles.copy()

            if len(allowed_vehicles) == 0:
                license_plate = generated_plate
            else:
                allowed_list.add(generated_plate)
                license_plate = choice(list(allowed_list))
            handle_gate_entry(license_plate, gate_status, mode, allowed_vehicles,start_time)

            if gate_status == "OPEN":
                handle_vehicle_exit(license_plate, gate_status,start_time)

            print(action_queue)
            batch.extend(points_from_queue(action_queue))
            action_queue = []
            if len(batch) >= batch_length:
                print(batch)
                write_api = client.write_api(write_options=SYNCHRONOUS)
                write_api.write(bucket="bucket", record=batch)
                batch = []
        start_time += timedelta(hours=1)

    if batch:
        write_api = client.write_api(write_options=SYNCHRONOUS)
        write_api.write(bucket="bucket", record=batch)

        batch = []
def points_from_queue(action_queue):
    points = []
    for user, action, time in action_queue:
        if user == "System":
            print('1')
            points.append(record_system_action(action, car_gate_id,time))
        elif action == "Vehicle entered":
            print('2')
            points.append(record_vehicle_entry(user, car_gate_id,time))
        elif action == "Vehicle exited":
            print('3')
            points.append(record_vehicle_exit(user, car_gate_id,time))

    return points

car_gate_id = "2c24c889-b58b-433a-b3ef-9759ccacde5f"
gate_status = "CLOSED"
mode = "PUBLIC"
allowed_vehicles = set()
start_time = datetime.utcnow() - timedelta(days=90)

client = InfluxDBClient(url="http://localhost:8086", token="AhVHBLJq5ykqHUpfdfWx25lwJjKPvEhZeP8fZzRyIxmJAWr7lhKLDuiGs33mQOTzEVmJEZ7Lm-Foo0EsfGSyBQ==", org="organization")
write_api = client.write_api(write_options=SYNCHRONOUS)

simulate_vehicles(gate_status, mode, allowed_vehicles, start_time, write_api, car_gate_id)

client.__del__()

from influxdb_client import InfluxDBClient, Point
from datetime import datetime, timedelta
from influxdb_client.client.write_api import SYNCHRONOUS
import random

BATCH_SIZE = 100  # Set the desired batch size

def send_power_influx_data_batch(points):
    token = "ZqgHocXYE-wlr76ucjWaUpjF0qKVmbeWjGme9s-h5zzDdol4qTNCl9tbANULxmKdLKbv5D-SqNwkXHaCBH93Bw=="
    org = "organization"
    url = "http://localhost:8086"
    bucket = "bucket"
    influxdb_client = InfluxDBClient(url=url, token=token, org=org)
    write_api = influxdb_client.write_api(write_options=SYNCHRONOUS)
    
    write_api.write(bucket=bucket, org=org, record=points)


def generate_data(start_date, end_date):
    id = "216c9d5b-321c-456f-8911-ae295cc0bc0c"
    current_date = start_date
    points = []

    while current_date <= end_date:
        action = random.choice(["treshold","connected","disconnected"])
        field = "plug"
        value = 0
        user = "System"
        if action == "treshold" :
            field = "value"
            user = random.choice(["Pare","Mika","Dejan Snicla"])
            value = random.randint(20,100)
            value = value*1.0
        if action == "disconnected" :
            value = round(random.uniform(-0.1,0.1),4)
        if action == "connected" :
            value = random.randint(0,6)
            value = value*1.0

        
        point = {
            "measurement": "Charger Actions",
            "tags": {
                "id": id,
                "user": user,
                "action": action
            },
            "time": current_date,
            "fields": {
                field: value
            }
        }
        
        points.append(point)

        if len(points) == BATCH_SIZE:
            send_power_influx_data_batch(points)
            points = []

        current_date += timedelta(hours=1)

    if points:
        send_power_influx_data_batch(points)


if __name__ == "__main__":
    start_date = datetime.utcnow() - timedelta(days=90)  
    end_date = datetime.utcnow()

    generate_data(start_date, end_date)

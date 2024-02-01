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
    id = "853c5d39-b2e4-4822-8945-ff59832a2aaa"
    
    current_date = start_date
    points = []

    while current_date <= end_date:
        choices = ["Pera", "Mika","Laza"]
        user = random.choice(choices)
        command = random.choice(["On","Off"])
        

        
        point = {
            "measurement": "Panel actions",
            "tags": {
                "id": id,
            },
            "time": current_date,
            "fields": {
                "user": user,
                "command": command

            }
        }
        
        points.append(point)

        if len(points) == BATCH_SIZE:
            send_power_influx_data_batch(points)
            points = []

        current_date += timedelta(hours=3)

    if points:
        send_power_influx_data_batch(points)


if __name__ == "__main__":
    start_date = datetime.utcnow() - timedelta(days=90)  
    end_date = datetime.utcnow()

    generate_data(start_date, end_date)

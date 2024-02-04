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
    id = "21044dca-c214-4e66-b6b4-86346254ed74"
    
    current_date = start_date
    points = []
    battery = 50.0

    while current_date <= end_date:
        choices = ["Grid", "Battery"]
        random_choice = random.choice(choices)
        random_float = random.uniform(-2, 2)
        battery += random_float
        if battery >100 :
            battery = 100.0
        if battery < 0 :
            battery = 0.0

        
        point = {
            "measurement": "Energy",
            "tags": {
                "id": id,
            },
            "time": current_date,
            "fields": {
                "energy": battery
            }
        }
        
        points.append(point)

        if len(points) == BATCH_SIZE:
            send_power_influx_data_batch(points)
            points = []

        current_date += timedelta(minutes=1)

    if points:
        send_power_influx_data_batch(points)


if __name__ == "__main__":
    start_date = datetime.utcnow() - timedelta(days=90)  
    end_date = datetime.utcnow()

    generate_data(start_date, end_date)

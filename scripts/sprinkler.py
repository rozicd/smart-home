from random import random, randint

import pause
from influxdb_client import InfluxDBClient, Point, WritePrecision
from datetime import datetime, timedelta
import time

# InfluxDB connection details
influx_url = "http://localhost:8086"
influx_token = "jIgP-SC2-N5FtigPJFwx31rnHEfS9RSVzqgilBd-jAJF4JENWdPLyIsNgUX05lwjX3YoiE6hQQ8lIbTOZ77ZPQ=="
influx_org = "organization"
influx_bucket = "bucket"

# Initialize InfluxDB client
client = InfluxDBClient(url=influx_url, token=influx_token, org=influx_org)
write_api = client.write_api()

# Sprinkler ID and user name
sprinkler_id = "7b131530-0310-4bcb-88a5-aef6614235f5"  # Replace with your actual sprinkler ID
user_name = "System"

# Write sprinkler actions for the past 90 days in batches of 100 with a pause of 60 seconds
end_date = datetime.utcnow()
start_date = end_date - timedelta(days=90)

current_date = start_date
points = []

while current_date <= end_date:

    action = "Sprinkler turned on"

    point = Point("Sprinkler actions") \
        .tag("Id", str(sprinkler_id)) \
        .field("action", action) \
        .field("user", user_name) \
        .time(current_date, WritePrecision.NS)

    points.append(point)

    action = "Sprinkler turned off"
    current_date += timedelta(minutes=randint(1, 32))

    point = Point("Sprinkler actions") \
        .tag("Id", str(sprinkler_id)) \
        .field("action", action) \
        .field("user", user_name) \
        .time(current_date, WritePrecision.NS)

    points.append(point)
    if len(points) == 100:
        write_api.write(bucket=influx_bucket, record=points)
        points = []

    current_date += timedelta(hours=1)

if points:
    write_api.write(bucket=influx_bucket, record=points)

pause.seconds(3)



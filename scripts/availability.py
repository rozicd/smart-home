from random import randint
import pause
from influxdb_client import InfluxDBClient, Point, WritePrecision
from datetime import datetime, timedelta
import time

# InfluxDB connection details
influx_url = "http://localhost:8086"
influx_token = "jIgP-SC2-N5FtigPJFwx31rnHEfS9RSVzqgilBd-jAJF4JENWdPLyIsNgUX05lwjX3YoiE6hQQ8lIbTOZ77ZPQ=="
influx_org = "organization"
influx_bucket = "bucket"

client = InfluxDBClient(url=influx_url, token=influx_token, org=influx_org)
write_api = client.write_api()

device_id = "3bfb7881-10a9-4a33-8a31-b936300bc87a"

end_date = datetime.utcnow()
start_date = end_date - timedelta(days=90)

current_date = start_date
points = []

while current_date <= end_date:
    point = Point("Device status") \
        .tag("Id", str(device_id)) \
        .field("status", 1) \
        .time(current_date, WritePrecision.NS)

    points.append(point)

    if len(points) >= 100:
        write_api.write(bucket=influx_bucket, record=points)
        points = []

    # Generate random intervals of 10 seconds difference
    current_date += timedelta(seconds=10)

    # Pause occasionally
    if randint(1, 120) == 1:
        pause_seconds = randint(1,3)
        current_date += timedelta(hours=pause_seconds)

if points:
    write_api.write(bucket=influx_bucket, record=points)

pause.seconds(6)

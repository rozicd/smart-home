import atexit
from influxdb_client import InfluxDBClient, Point, WritePrecision
from datetime import datetime, timedelta
import math
import ephem
import pause
from influxdb_client.client.write_api import SYNCHRONOUS

# InfluxDB settings
influx_url = "http://localhost:8086"
influx_token = "AhVHBLJq5ykqHUpfdfWx25lwJjKPvEhZeP8fZzRyIxmJAWr7lhKLDuiGs33mQOTzEVmJEZ7Lm-Foo0EsfGSyBQ=="
influx_org = "organization"
influx_bucket = "bucket"

# Lamp ID (replace with your actual lamp ID)
lamp_id = "9b3c6b79-6eda-4444-b5ea-a45f30f78765"

# Connect to InfluxDB
client = InfluxDBClient(url=influx_url, token=influx_token, org=influx_org)
write_api = client.write_api(write_options=SYNCHRONOUS)


# Lamp simulation logic
def calculate_solar_elevation(latitude, longitude, date_time):
    observer = ephem.Observer()
    observer.lat = str(latitude)
    observer.lon = str(longitude)
    observer.date = date_time.strftime('%Y-%m-%d %H:%M:%S')

    sun = ephem.Sun()
    sun.compute(observer)
    solar_elevation = math.degrees(sun.alt)
    return solar_elevation

def solar_elevation_to_lux(solar_elevation):
    lux = max(0, math.sin(math.radians(solar_elevation)))
    return lux

# Batch size for writing to InfluxDB
batch_size = 100
batch_points = []

start_date = datetime.utcnow() - timedelta(days=90)
while start_date <= datetime.utcnow():
    solar_elevation = calculate_solar_elevation(44.786568, 20.448921, start_date)
    lux_value = solar_elevation_to_lux(solar_elevation)
    print(start_date)
    normalized_solar_elevation = lux_value * 150
    adjusted_value = max(0, normalized_solar_elevation)

    current_light = adjusted_value
    power_state = 0 if current_light >= 50 else 1

    point = Point("Lamp data") \
        .tag("Id", str(lamp_id)) \
        .field("light", float(current_light)) \
        .field("power", int(power_state)) \
        .time(start_date, WritePrecision.NS)

    batch_points.append(point)

    print(point)
    if len(batch_points) >= batch_size:
        print(batch_points)
        write_api.write(bucket=influx_bucket, record=batch_points)

        # Clear the batch_points list
        batch_points = []

    start_date += timedelta(minutes=10)

# Write any remaining points in the batch
if batch_points:
    write_api.write(bucket=influx_bucket, record=batch_points)

print("Data insertion completed.")
pause.seconds(6)

import atexit
from influxdb_client import InfluxDBClient, Point
from datetime import datetime, timedelta
import math
import ephem
import pause

# InfluxDB settings
influx_url = "http://localhost:8086"
influx_token = "jIgP-SC2-N5FtigPJFwx31rnHEfS9RSVzqgilBd-jAJF4JENWdPLyIsNgUX05lwjX3YoiE6hQQ8lIbTOZ77ZPQ=="
influx_org = "organization"
influx_bucket = "bucket"

# Lamp ID (replace with your actual lamp ID)
lamp_id = "a54e7a70-9a8a-4e8d-9fb9-d2941d94b7f0"

# Connect to InfluxDB
client = InfluxDBClient(url=influx_url, token=influx_token, org=influx_org)

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

    normalized_solar_elevation = lux_value * 150
    adjusted_value = max(0, normalized_solar_elevation)

    current_light = adjusted_value
    power_state = 1 if current_light >= 50 else 0

    point = Point("Lamp data") \
        .tag("Id", lamp_id) \
        .field("light", current_light) \
        .field("power", power_state) \

    batch_points.append(point)

    if len(batch_points) >= batch_size:
        # Write the batch to InfluxDB
        write_api = client.write_api()
        write_api.write(bucket=influx_bucket, record=batch_points)

        # Clear the batch_points list
        batch_points = []

    start_date += timedelta(minutes=1)

# Write any remaining points in the batch
if batch_points:
    write_api = client.write_api()
    write_api.write(bucket=influx_bucket, record=batch_points)

print("Data insertion completed.")

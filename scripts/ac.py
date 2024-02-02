from influxdb_client import InfluxDBClient, Point, WritePrecision
from datetime import datetime, timedelta
from influxdb_client.client.write_api import SYNCHRONOUS
import random

influx_url = "http://localhost:8086"
influx_token = "KxlFDU7Y3bqHuhO_w0xdmbXH8lhnDHwP144_TVkDKFGeNxKL1bBSeBpm1Gg9o_Lp1ESB1nH12TiXgCxQsnD-yw=="
influx_org = "organization"
influx_bucket = "bucket"

client = InfluxDBClient(url=influx_url, token=influx_token, org=influx_org)
write_api = client.write_api(write_options=SYNCHRONOUS)

ac_id = "50fca3a7-bc05-48f5-935e-d5cf18d69824"
user_name = "System"
user_id = "83429226-2cce-469b-bba8-a322bb7a0712"

end_date = datetime.now()
start_date = end_date - timedelta(days=90)
current_date = start_date
points = []

number = 0
def get_temperature_and_mode():
    modes = ["FAN", "HEATING", "AUTOMATIC", "COOLING"]
    mode_for_return = random.choice(modes)
    temperature_for_return = random.randint(16, 30)
    return mode_for_return, temperature_for_return


while current_date <= end_date:
    mode, temperature = get_temperature_and_mode()
    point = Point("AC actions") \
        .tag("Id", str(ac_id)) \
        .field("currentTemp", float(temperature)) \
        .field("mode", mode) \
        .field("user", user_name) \
        .field("userId", user_id) \
        .time(current_date, WritePrecision.NS)

    points.append(point)
    if len(points) == 100:
        number += len(points)
        write_api.write(bucket=influx_bucket, org=influx_org, record=points)
        points = []

    current_date += timedelta(hours=5)

if points:
    number += len(points)
    write_api.write(bucket=influx_bucket, org=influx_org, record=points)
print(number)

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

esc_id = "358ad51d-4cc2-47cf-8850-3bee7413c2f3"
user_name = "System"
user_id = "83429226-2cce-469b-bba8-a322bb7a0712"

end_date = datetime.now()
start_date = end_date - timedelta(days=90)
current_date = start_date
points = []

number = 0


def get_readings():
    room_temperature_for_return = random.randint(19,23)
    air_humidity_for_return = random.randint(40,50)

    return room_temperature_for_return, air_humidity_for_return


while current_date <= end_date:
    temprature, humidity = get_readings()
    point = Point("ESC readings") \
        .tag("Id", str(esc_id)) \
        .field("airHumidity", float(humidity)) \
        .field("roomTemperature", float(temprature)) \
        .time(current_date, WritePrecision.NS)

    points.append(point)
    if len(points) == 100:
        number += len(points)
        write_api.write(bucket=influx_bucket, org=influx_org, record=points)
        points = []

    current_date += timedelta(minutes=1)

if points:
    number += len(points)
    write_api.write(bucket=influx_bucket, org=influx_org, record=points)
print(number)

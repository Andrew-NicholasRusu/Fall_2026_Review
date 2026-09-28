"Lazaro E. Sagarra V. & Andrew Rusu - 2430745 & 2432744"
## This is the file that simulates 3 sensors:

import json 
import requests 
import time 

# Reads the config.json file and return credentials as a dictionary:
def load_credentials(filename="config.json"): 
    with open(filename, "r") as file: credentials = json.load(file)
    return credentials
 
creds = load_credentials() 
ADAFRUIT_IO_USERNAME = creds["adafruit_io_username"] 
ADAFRUIT_IO_KEY = creds["adafruit_io_key"] 

FEEDS = { 
    "temperature": "temperature", 
    "humidity": "humidity", 
    "pressure": "pressure" 
} 
''' 
This function read line by line environment_data.txt 
Then store the data inside an array like data=[] 
''' 

# Reads environmental_data.txt one line at the time
def read_json_data(filename): 
    data = []

    with open (filename, "r") as file:
        for line in file:
            line = line.strip()

            if line:
                reading = json.loads(line)
                data.append(reading)
    return data

def send_to_adafruit_io(feed_name, value):

    url = f"https://io.adafruit.com/api/v2/{ADAFRUIT_IO_USERNAME}/feeds/{feed_name}/data"

    headers = {
        "X-AIO-Key": ADAFRUIT_IO_KEY
        } 

    data = {
        "value": value
        } 
 
    response = requests.post(
        url, 
        headers=headers, 
        json=data
    ) 
    return response.status_code == 200 

def main(): 

    # Reads the JSONL file 
    sensor_data = read_json_data('environmental_data.txt') 

    # Send each reading to respective feeds 
    for reading in sensor_data:
        timestamp = reading["timestamp"]
        print(f"\nTimestamp: {timestamp}")
        for sensor, feed_name in FEEDS.items():
            value = reading[sensor]
            success = send_to_adafruit_io(feed_name, value)
            if success:
                print(f"{sensor}:{value}-> sent successfully")
            else:
                print(f"{sensor}:{value}->failed to send")
    # Small delay between readings using "time" import time.sleep(2)

if __name__ == "__main__": 
    main()
import time
from datetime import datetime
import board
import adafruit_dht

# DHT11 data pin connected to GPIO11 
dht = adafruit_dht.DHT11(board.D21)
file_name = "temperature_log.txt"

try:
    while True:
        try:
            temperature = dht.tempeperature
            humidity = dht.humidity
            now = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
            line = f"{now} | "
            f"Temperature: {temperature:.1f} C | "
            f"Humidity: {humidity:.1f}%"

            # Show rading in terminal
            print(line)

            # Append reading to text file
            with open (file_name, "a") as file:
                file.write(line + "\n")

        except RunTimeError as error:
            # DHT11 can occasionally fail to return a reading
            print("Sensor reading error:", error)
        time.sleep(30)
except KeyboardInterrupt:
    pass
finally:
    dht.exit()
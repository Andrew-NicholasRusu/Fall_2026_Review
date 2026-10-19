# HC-SR04 on a Raspberry Pi 5
from gpiozero import DistanceSensor
from time import sleep

# TRIG → GPIO23 (pin 16), ECHO → divider → GPIO24 (pin 18)
sensor = DistanceSensor(echo=24, trigger=23, max_distance=4)

try:
    while True:
        cm = sensor.distance * 100 # metres -> cm
        print(f"Distance: {cm:6.1f}cm")
        sleep(0.5)
except KeyboardInterrupt:
    print("Stopped")
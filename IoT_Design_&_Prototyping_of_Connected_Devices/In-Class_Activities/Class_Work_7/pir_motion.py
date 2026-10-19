# HC-SR501 on a Raspberry Pi 5
from gpiozero import MotionSensor, LED
from datetime import datetime
from signal import pause
from time import sleep

"MotionSensor calls your functions when OUT goes HIGH or LOW. "
"The script itself just waits."

pir = MotionSensor(17) # OUT → GPIO17 (pin 11)
led = LED(27) # GPIO27 (pin 13) → 330 Ω → LED

def on_motion():
    led.on()
    print(f"{datetime.now():%H:%M:%S} Motion detected")

def on_clear():
    led.off()
    print(f"{datetime.now():%H:%M:%S} All clear")

print("Warming up the PIR sensor (60 s)...")
sleep(60)
pir.when_motion = on_motion
pir.when_no_motion = on_clear
print("Ready: move in front of the sensor")
pause()     # keep the script running

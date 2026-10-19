# Motion wakes the sonar; distance sets LED brightness
from gpiozero import MotionSensor, DistanceSensor, PWMLED
from time import sleep

"The PIR decides when to measure. The distance sets the LED's PWM value."

pir = MotionSensor(17)
sonar = DistanceSensor(echo=24, trigger=23, max_distance=2)
led = PWMLED(27)
NEAR_CM, FAR_CM = 10, 150 # bright at 10, off past 150

def brightness(cm):
    b = (FAR_CM - cm) / (FAR_CM - NEAR_CM) # closer -> bigger
    return max (0.0, min(1.0, b))   # keep it in 0-1

sleep(60)
print("Armed: waiting for motion")
while True:
    pir.wait_for_motion()       # 1. Someone is here
    while pir.motion_detected:      # 2. How close are they?
        cm = sonar.distance * 100
        led.value = brightness(cm)      # 3. closer = brighter
        print(f"{cm:5.1f} cm -> LED {led.value:.2f}")
        sleep(0.1)
    # 4. area clear 
    led.off()          
    print("Clear: re-armed")
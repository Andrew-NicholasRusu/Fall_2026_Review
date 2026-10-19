
# NOW import your hardware 
from gpiozero import Device

led_green = PWMLED(17, frequency = 1000)
led_green = PWMLED(27, frequency = 1000)
led_green = PWMLED(22, frequency = 1000)

while True:
    print("Setting LED to 30% brightness...")
    led_green.value = 0.30 # 50% duty cycle
    time.sleep(5)

    print("Setting LED to 95% brightness and pusling...")
    led_green.value = 0.95 # Brighter
    led.pulse() # Smooth fade in and out in the background

    time.sleep(5)
    leed_green.off()
    print("LED turned off.")


print ("Setting LED to 50% brightness...")

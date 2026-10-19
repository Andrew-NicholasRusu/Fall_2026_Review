import time
import RPi.GPIO as GPIO

class ButtonLED:
    def __init__(self, button_pin, led_pin, pwm_frequency = 100):
        self.button_pin = button_pin
        self.led_pin = led_pin

        # Use BCM GPIO numbering
        GPIO.setmode(GPIO.BCM)

        # Button is connected between the GPIO pin and GND
        GPIO.setup(
            self.button_pin,
            GPIO.IN,
            pull_up_down = GPIO.PUD_UP
        )

        GPIO.setup(self.led_pin, GPIO.OUT)

        # Create PWM object
        # Frequency is measured in hertz
        self.led_pwm = GPIO.PWM(self.led_pin, pwm_frequency)

        # Start with the LED off
        self.led_pwm.start(0)

    def is_pressed(self):
        # Returns True when the button is pressed.
        # Because of the pull-up resistor, pressed = GPIO.LOW.
        return GPIO.input(self.button_pin) == GPIO.LOW

    def set_brightness(self, duty_cycle):
        # Set LED brightness from 0 to 100 percent.
        duty_cycle = max(0, min(100, duty_cycle))
        self.led_pwm.ChangeDutyCycle(duty_cycle)

    def update(self):
        # Turn the LED on at 100% brightness while pressed.
        # Turn it off when released.
        if self.is_pressed():
            self.set_brightness(100)
            # self.set_brightness(50), only if you want to turn the LED on half brightness while the button is pressed.
        else:
            self.set_brightness(0)

    def cleanup(self):
        self.led_pwm.stop()
        GPIO.cleanup()

def main():
    button_led = ButtonLED(
        button_pin=17,
        led_pin=18,
        pwm_frequency=100
    )

    try:
        while True:
            button_led.update()
            time.sleep(0.01)

    except KeyboardInterrupt:
        print("Program stopped.")

    finally:
        button_led.cleanup()

if __name__ == "__main__":
    main()

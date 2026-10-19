import time
import RPi.GPIO as GPIO

class Button:
    def __init__(self, button_pin, led_pin):
        self.button_pin = button_pin
        self.led_pin = led_pin

        # Use BCM pin numbering
        GPIO.setmode(GPIO.BCM)

        # Button uses the internal pull-up resistor
        GPIO.setup(
            self.button_pin,
            GPIO.IN,
            pull_up_down=GPIO.PUD_UP
        )

        GPIO.setup(self.led_pin, GPIO.OUT)
        GPIO.output(self.led_pin, GPIO.LOW)

    def is_pressed(self):
        # Returns true when the button is pressed:
        return GPIO.input(self.button_pin) == GPIO.LOW

    def update(self):
        # Turns the LED on while the button is pressed.
        if self.is_pressed():
            GPIO.output(self.led_pin, GPIO.HIGH)
        else:
            GPIO.output(self.led_pin, GPIO.LOW)

    def cleanup(self):
        GPIO.output(self.led_pin, GPIO.LOW)
        GPIO.cleanup()

def main():
    # GPIO numbers using BCM numbering
    button = Button (button_pin = 17, led_pin= 18)

    try:
        while True:
            button.update()
            time.sleep(0.01)

    except KeyboardInterrupt:
        print("Program stopped.")

    finally:
        button.cleanup()

if __name__ == "__main__":
    main()
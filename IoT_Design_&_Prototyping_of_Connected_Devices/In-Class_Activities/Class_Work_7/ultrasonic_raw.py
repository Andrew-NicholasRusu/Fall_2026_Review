import lgpio, time

TRIG, ECHO = 23, 24

# Open GPIO chip
h = lgpio.gpiochip_open(0) # Pi 5 header chip

# Configure GPIO pins
lgpio.gpio_claim_output(h, TRIG, 0)
lgpio.gpio_claim_input(h, ECHO)

def measure_cm():
    # 1. 10 μs trigger pulse (send a 10 microsecond trigger pulse)
    lgpio.gpio_write(h, TRIG, 1)    
    time.sleep(10e-6)
    lgpio.gpio_write(h, TRIG, 0)

    # 50 ms timeout
    limit = time.monotonic() + 0.05     

    # 2. wait for ECHO HIGH
    while lgpio.gpio_read(h, ECHO) == 0:    
        if time.monotonic() > limit: return None
    start = time.monotonic()

    # 3. time the pulse
    while lgpio.gpio_read(h, ECHO) == 1:    
        if time.monotonic() > limit: return None
    t = time.monotonic() - start
    # 4. seconds → cm
    return t * 34300 / 2    

try:
    while True:
        d = measure_cm()
        print("no echo" if d is None else f"{d:.1f} cm")
        time.sleep(0.1)
finally:
    lgpio.gpiochip_close(h)
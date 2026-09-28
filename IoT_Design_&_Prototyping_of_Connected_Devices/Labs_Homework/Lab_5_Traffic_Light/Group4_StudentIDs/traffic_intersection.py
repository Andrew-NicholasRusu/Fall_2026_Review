# Team Name: Group 4
# Student IDs: 2430745 & 2......
# Assignment 3 - 4-Way Intersection Control Raspberry Pi 5

from gpiozero import LED
from time import sleep

# ============================================================
# GPIO PIN CONFIGURATION (BCM numbering)
# ============================================================
LIGHTS = {
    "north": {
        "red": LED(17),
        "yellow": LED(27),
        "green": LED(22),
    },
    "south": {
        "red": LED(12),
        "yellow": LED(16),
        "green": LED(20),
    },
    "east": {
        "red": LED(5),
        "yellow": LED(6),
        "green": LED(13),
    },
    "west": {
        "red": LED(23),
        "yellow": LED(24),
        "green": LED(25),
    },
}

# The assignment requires a 10-second GREEN right-of-way phase.
GREEN_TIME = 10
YELLOW_TIME = 2

# A short all-red interval is used as a safety clearance.
ALL_RED_TIME = 1


# ============================================================
# HELPER FUNCTIONS
# ============================================================
def set_light(direction_name, colour):
    """Turn on exactly one colour for one direction."""
    direction = LIGHTS[direction_name]

    if colour not in direction:
        raise ValueError(
            f"Invalid colour '{colour}' for direction '{direction_name}'"
        )

    for colour_name, led in direction.items():
        if colour_name == colour:
            led.on()
        else:
            led.off()


def all_red():
    """Put the entire intersection into the safe ALL-RED state."""
    for direction_name in LIGHTS:
        set_light(direction_name, "red")

    print("\n====================================")
    print("SAFE STATE: ALL DIRECTIONS RED")
    print("====================================")


def verify_no_conflicting_greens():
    """Safety check: NS and EW must never both have green LEDs on."""
    ns_green = LIGHTS["north"]["green"].is_lit or LIGHTS["south"]["green"].is_lit
    ew_green = LIGHTS["east"]["green"].is_lit or LIGHTS["west"]["green"].is_lit

    if ns_green and ew_green:
        # Immediately force a safe state before raising the error.
        all_red()
        raise RuntimeError("SAFETY ERROR: conflicting green signals detected")
    
    
def all_off():
    """Turn every LED OFF for diagnostic testing."""
    for direction in LIGHTS.values():
        for led in direction.values():
            led.off()


def wiring_diagnostic():
    """
    Test every LED individually before traffic cycles begin.

    The Raspberry Pi cannot automatically determine whether an LED
    is physically connected to the correct GPIO pin, so the user
    confirms that the expected LED actually lights.
    """

    print("\n")
    print("====================================")
    print("STARTUP WIRING DIAGNOSTIC")
    print("====================================")
    print("Each LED will be tested individually.")
    print("Look at the breadboard and confirm that")
    print("the CORRECT LED lights up.")
    print("If the wrong LED lights, or no LED lights,")
    print("the program will stop before traffic cycles.")
    print("====================================\n")

    all_off()

    # Test every direction and colour individually.
    for direction_name, direction in LIGHTS.items():

        for colour_name, led in direction.items():

            # Make sure nothing else is illuminated.
            all_off()

            print("------------------------------------")
            print(f"TESTING: {direction_name.upper()} {colour_name.upper()}")
            print(f"Expected GPIO: {led.pin.number}")
            print("------------------------------------")

            led.on()

            response = input(
                f"Is the {direction_name.upper()} {colour_name.upper()} "
                "LED the ONLY LED that is lit? (y/n): "
            ).strip().lower()

            led.off()

            if response != "y":
                all_off()

                print("\n====================================")
                print("WIRING DIAGNOSTIC FAILED")
                print("====================================")
                print(
                    f"Problem detected with: "
                    f"{direction_name.upper()} {colour_name.upper()}"
                )
                print(f"Expected GPIO: {led.pin.number}")
                print("\nCheck:")
                print("  - LED is connected to the correct GPIO")
                print("  - LED polarity is correct")
                print("  - Resistor is connected correctly")
                print("  - Jumper wires are firmly connected")
                print("  - GPIO number uses BCM numbering")
                print("====================================")

                raise RuntimeError(
                    f"Wiring diagnostic failed for "
                    f"{direction_name} {colour_name}"
                )

    all_off()

    print("\n====================================")
    print("WIRING DIAGNOSTIC PASSED")
    print("All 12 LEDs were confirmed.")
    print("Starting traffic controller...")
    print("====================================\n")

def ask_run_diagnostic():
    """Ask the user whether to run the LED wiring diagnostic."""

    while True:
        response = input(
            "\nWould you like to run the startup wiring diagnostic? "
            "(y/n): "
        ).strip().lower()

        if response == "y":
            return True

        if response == "n":
            return False

        print("Invalid choice. Please enter 'y' for Yes or 'n' for No.")


# ============================================================
# TRAFFIC STATES
# ============================================================
def north_south_green():
    """North/South GREEN; East/West RED."""
    set_light("north", "green")
    set_light("south", "green")
    set_light("east", "red")
    set_light("west", "red")
    verify_no_conflicting_greens()

    print("\n------------------------------------")
    print("NORTH-SOUTH : GREEN")
    print("EAST-WEST   : RED")
    print("------------------------------------")


def north_south_yellow():
    """North/South YELLOW; East/West RED."""
    set_light("north", "yellow")
    set_light("south", "yellow")
    set_light("east", "red")
    set_light("west", "red")

    print("\n------------------------------------")
    print("NORTH-SOUTH : YELLOW")
    print("EAST-WEST   : RED")
    print("------------------------------------")


def east_west_green():
    """East/West GREEN; North/South RED."""
    # Set the old right-of-way to RED before enabling the new GREEN.
    set_light("north", "red")
    set_light("south", "red")
    set_light("east", "green")
    set_light("west", "green")
    verify_no_conflicting_greens()

    print("\n------------------------------------")
    print("NORTH-SOUTH : RED")
    print("EAST-WEST   : GREEN")
    print("------------------------------------")


def east_west_yellow():
    """East/West YELLOW; North/South RED."""
    set_light("north", "red")
    set_light("south", "red")
    set_light("east", "yellow")
    set_light("west", "yellow")

    print("\n------------------------------------")
    print("NORTH-SOUTH : RED")
    print("EAST-WEST   : YELLOW")
    print("------------------------------------")


def clearance():
    """Keep all approaches RED for the selected clearance time."""
    all_red()
    if ALL_RED_TIME > 0:
        print(f"Safety clearance: {ALL_RED_TIME} second(s)")
        sleep(ALL_RED_TIME)


# ============================================================
# COMPLETE PHASES
# ============================================================
def run_north_south_phase():
    north_south_green()
    print(f"North-South GREEN for {GREEN_TIME} seconds")
    sleep(GREEN_TIME)

    north_south_yellow()
    print(f"North-South YELLOW for {YELLOW_TIME} seconds")
    sleep(YELLOW_TIME)

    clearance()


def run_east_west_phase():
    east_west_green()
    print(f"East-West GREEN for {GREEN_TIME} seconds")
    sleep(GREEN_TIME)

    east_west_yellow()
    print(f"East-West YELLOW for {YELLOW_TIME} seconds")
    sleep(YELLOW_TIME)

    clearance()


# ============================================================
# SAFE SHUTDOWN
# ============================================================
def safe_shutdown():
    """Leave the intersection ALL-RED before GPIO cleanup/exit."""
    print("\nTraffic controller is shutting down.")
    try:
        all_red()
        print("Intersection placed in safe ALL-RED state.")
    except Exception as error:
        print(f"Could not complete normal safe shutdown: {error}")


# ============================================================
# MAIN PROGRAM
# ============================================================
try:
    print("\n====================================")
    print("4-WAY TRAFFIC INTERSECTION CONTROLLER")
    print("Raspberry Pi 5 + gpiozero")
    print("====================================")

    # Known safe startup state.
    all_red()
    print("System starting from known safe state...")
    sleep(2)
    
    
    # Ask whether the user wants to perform the wiring diagnostic.
    if ask_run_diagnostic():
        wiring_diagnostic()

        # Return to a known safe state after the diagnostic.
        all_red()
        print("Diagnostic complete. Starting from ALL-RED state...")
        
    else:
        print("\nWiring diagnostic skipped.")
        print("Starting traffic controller from ALL-RED state...")
        

    cycle_number = 1

    while True:
        print("\n====================================")
        print(f"TRAFFIC CYCLE {cycle_number}")
        print("====================================")

        run_north_south_phase()
        run_east_west_phase()

        cycle_number += 1

except KeyboardInterrupt:
    print("\nCTRL+C detected. Preparing safe shutdown.")

except Exception as error:
    print("\nUnexpected error occurred:")
    print(error)
    # The finally block will still attempt safe shutdown.

finally:
    safe_shutdown()

    # gpiozero handles its device cleanup on program exit. Explicitly
    # closing each LED also makes the shutdown intent clear.
    for direction in LIGHTS.values():
        for led in direction.values():
            led.close()

    print("Traffic controller stopped.")

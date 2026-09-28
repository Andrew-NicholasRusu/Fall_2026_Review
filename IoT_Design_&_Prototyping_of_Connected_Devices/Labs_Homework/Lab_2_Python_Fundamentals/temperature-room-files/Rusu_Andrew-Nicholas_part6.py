"Part 6: Case Study: Home Temperature Monitoring"

from pathlib import Path # imports the Path class from the pathlib module, which provides an object-oriented interface for working with file system paths.

BASE_DIR = Path(__file__).parent # sets the base directory to the current file's directory, allowing for relative file paths.

FILENAMES = [
    "my_home_tempreture-2026-09-01.txt",
    "my_home_tempreture-2026-09-02.txt",
    "my_home_tempreture-2026-09-03.txt",
]

ROOMS = [101, 102, 103] # defines a list of room numbers to be used for calculating average temperatures per room.

# Step 1. Reading a single file:
def read_temperature_file(filename):

    records = []
    full_path = BASE_DIR / filename
    try:
        with open(full_path, "r") as file:
            lines = file.readlines()

        # Skip the header (first line) and process the rest
        for line in lines[1:]:
            line = line.strip()
            if line == "":
                continue

            parts = line.split(",") 
            if len(parts) != 4:
                continue

            record = {
                "id": int(parts[0]),
                "datetime": parts[1].strip(),
                "room_number": int(parts[2]),
                "temperature_c": float(parts[3]),
            }
            records.append(record)

    except FileNotFoundError:
        print(f"Error: File '{full_path}' was not found.")
    except ValueError:
        print(f"Error: File '{full_path}' contains invalid data.")

    return records

# Step 2. Combining all files:
def load_all_records(filenames):
    all_records = []
    for filename in filenames:
        records = read_temperature_file (filename) # calls the read_temperature_file function for each filename in the list.
        all_records.extend(records)
    return all_records

# Step 3. Finding the hottest reading
def find_hottest(records):
    if not records:
        return None
    hottest = records[0]
    for record in records:
        if record["temperature_c"] > hottest["temperature_c"]:
            hottest = record
    return hottest

# Step 4. Calculating the average:
def calculate_average(records):
    if not records:
        return 0.0
    total = 0.0
    for record in records:
        total += record["temperature_c"]
    return total / len(records)

# Step 5: Finding the average per room:
def average_by_room(records, rooms):
    averages = {}
    for room in rooms:
        room_records = [r for r in records if r ["room_number"] == room]
        averages[room] = calculate_average(room_records)
    return averages

# Main 
def main():
    all_records = load_all_records(FILENAMES)

    if not all_records:
        print("No data was loaded.")
        return 

    all_records.sort(key=lambda r: r["id"])

    hottest = find_hottest(all_records) 
    # calls the find_hottest function to find the record with the highest temperature from all_records.

    room_averages = average_by_room(all_records, ROOMS) 
    # calls the average_by_room function to calculate the average temperature for each room in ROOMS based on all_records.

    overall_average = calculate_average(all_records) 
    # calls the calculate_average function to compute the overall average temperature from all_records.

    print("HOTTEST READING")
    date_part, time_part = hottest["datetime"].split(" ") # splits the datetime string into date and time parts for better readability.
    print(f"Temperature: {hottest['temperature_c']:.1f} °C")
    print(f"Date: {date_part}")
    print(f"Time: {time_part}")
    print(f"Room: {hottest['room_number']}")
    print(f"ID: {hottest['id']}")
    print() # Space

    print("AVERAGE SENSOR TEMPERATURE")
    for room in ROOMS:
        print(f"Room {room}: {room_averages[room]:.2f} °C")
    print() # Space

    print(f"Overall Average: {overall_average:.2f} °C")

if __name__ == "__main__": 
    # main guard to ensure that the main function is only executed when the script is run directly, not when imported as a module.
    main()


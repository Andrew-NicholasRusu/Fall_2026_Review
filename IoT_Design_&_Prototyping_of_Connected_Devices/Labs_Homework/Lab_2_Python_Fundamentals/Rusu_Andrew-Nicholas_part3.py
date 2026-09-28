'Part 3: Python Data Structures'

# A. List
devices = ["Laptop", "Router", "Printer", "Server", "Switch"]

for device in devices:
    print(f" {device}") # prints all the devices in the list.

devices.append("Tablet") # adds a new device to the list, which is "Tablet"
print(devices)

devices.remove("Printer") # removes "Printer"
print(f"Number of devices: {len(devices)}") # Displays the number of device in the final list.

print() # Space between the outputs:

# B. Tuple
computer = ("Dell", "Laptop", 16, 512)
print("Brand:", computer[0])
print("Device Type:", computer[1])
print("RAM:", computer[2], "GB")
print("Storage:", computer[3], "GB")

print() # Space between the outputs:

# Why might a tuple be useful when we do not want data to change? 
# A tuple is immutable: once it is created, its values cannot be modified.
# This protects fixed data (like device specifications) from being
# changed accidentally and makes the program safer and easier to reason about.

# C. Dictionary
student = {
    "Name": "Alex",
    "Student_id": 10025,
    "Program": "IT",
    "Semester": 1
}

print("Student Name:", student["Name"]) # Displays the student's name.
print("Program:", student["Program"]) # Displays the student's program.

student["semester"] = 2 # Updates the student's semester to 2.
print("Student's updated semester:", student["Semester"])

student["email"] = "alex@gmail.com" # Adds a new key-value pair called email.
print("Student's email:", student["email"])

for key, value in student.items(): # Uses a loop to display all the key-value pairs in the dictionary.
    print(f" {key}: {value}") 

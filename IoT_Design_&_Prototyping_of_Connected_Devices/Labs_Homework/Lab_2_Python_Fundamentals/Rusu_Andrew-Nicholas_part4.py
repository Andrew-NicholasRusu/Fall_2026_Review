'Part 4: Files and Exception Handling'

FILENAME = "numbers.txt" # creates numbers.txt

def get_three_numbers():
    numbers = []
    for i in range(1, 4):
        while True:
            try: # Uses exception handling to ensure that the user inputs valid numbers.
                value = float(input(f"Enter number {i}:"))
                numbers.append(value) # appends the valid number to the list of numbers.
                break
            except ValueError: # ValueError is raised when the input cannot be converted to a float, prompting the user to enter a valid number.
                print("Invalid input. Please enter a number.")
    return numbers

def write_numbers(numbers, filename):
    with open(filename, "w") as file:
        for number in numbers:
            file.write(f"{number}\n")

def read_and_average(filename):
    try:
        with open(filename, "r") as file:
            lines = file.readlines()

        total = 0.0
        count = 0
        for line in lines:
            total += float(line.strip())
            count += 1

        if count == 0:
            print("The file is empty.")
            return None

    except FileNotFoundError: # FileNotFoundError is raised when the specified file does not exist.
        print(f"Error: File '{filename}' was not found.")
        return None
    except ValueError:
        print("Error: The file contains invalid data.")
        return None

print("Enter 3 numbers to save in the file:")
user_numbers = get_three_numbers()

write_numbers(user_numbers, FILENAME) 
print(f"\nNumbers saved to {FILENAME}.")

average = read_and_average(FILENAME)
if average is not None: 
    print(f"Average of the three numbers: {average:.2f}")
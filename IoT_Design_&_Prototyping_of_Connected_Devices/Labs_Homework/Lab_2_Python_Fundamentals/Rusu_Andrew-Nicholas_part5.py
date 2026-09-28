'Part 5: *args and **kwargs'

# A. *args
def calculate_average(*args):

    if len(args) == 0: # If no arguments are provided, the function returns 0.0 to avoid division by zero.
        return 0.0
    return sum(args) / len(args)

print("Average of 10, 20, and 30:", calculate_average(10, 20, 30))
print("Average of 10, 20, 30, 40, and 50:", calculate_average(10, 20, 30, 40, 50))

# B. **kwargs
def display_device(**kwargs):
    for key, value in kwargs.items(): # Uses a loop to display all the key-value pairs in the dictionary.
        print(f"{key}: {value}")

    display_device(
        brand="Dell",
        model="Latitude",
        ram="16 GB",
        storage="512 GB"
    )

# Difference between *args and **kwargs: 
# *args is used to pass a variable number of non-keyword arguments to a function, 
# while **kwargs is used to pass a variable number of keyword arguments to a function.
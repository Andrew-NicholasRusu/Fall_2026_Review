'Part 1: Functions in Python'

# Question 1:
def celsius_to_farenheit(celsius):
    return (celsius * 9 / 5) + 32
celsius_to_farenheit(70) #  receives a temperature in Celsius and returns its Fahrenheit equivalent. 
celsius_to_farenheit(30)
celsius_to_farenheit(50)

print (celsius_to_farenheit(70))
print (celsius_to_farenheit(30))
print (celsius_to_farenheit(50))

# Question 2:
def find_largest(num1, num2, num3):
    return max(num1, num2, num3)
find_largest(12, 8, 20) # receives three numbers and returns the largest number. 
print (find_largest(12, 8, 20))

# Question 3:
def check_grade(mark):
    if mark >= 90:
        return "A"
    elif mark >= 80:
        return "B"
    elif mark >= 70:
        return "C"
    elif mark >= 60:
        return "D"
    else:
        return "F"
grade = 70 # Asks the user for a mark and call the function to display the result. 
if grade >= 60:
    print("Pass")
else:
    print("Fail")

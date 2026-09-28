'Part 2: Loops in Python'

# Question 1:
for number in range (1, 21):
    print(number) # prints all numbers from 1 to 20.

print() # Space between the outputs:

# Question 2:
for evenCount in range (1, 51):
    if evenCount % 2 == 0:
        print(evenCount) # prints all even numbers from 1 to 50.

print() # Space between the outputs:

# Question 3:
numbers = [12, 18, 25, 31, 42, 50]
total = 0
count = 0

for value in numbers:
    total += value
    count += 1

average = total / count

print(f"Total: {total}") # calculates the total of a list of numbers.
print(f"Count: {count}") #  calculates the count of a list of numbers.
print(f"Average: {average}") # calculates the average of a list of numbers.
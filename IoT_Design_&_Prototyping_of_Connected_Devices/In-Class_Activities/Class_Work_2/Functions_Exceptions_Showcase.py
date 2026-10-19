"Functions:  the primary and most important method of code organization and reuse in Python."
import re
from pathlib import Path

# Example:
def my_function(x, y, z = 1.5):
    if z > 1:
        return z * (x + y)
    else:
        return z / (x + y)


def my_keyword_function(x, y, z=1.5):
    "Use the same calculation to demonstrate positional and keyword arguments."
    return my_function(x, y, z)

# Returning Multiple Values

def f():
    a = 5
    b = 6
    c = 7
    return {'a' : a, 'b' : b, 'c' : c}

# Positional arguments and keyword arguments
# Each function can have positional arguments and keyword arguments. Keyword arguments are 
# most commonly used to specify default values or optional arguments.

# Functions Are Objects
# Since Python functions are objects, many constructs can be easily expressed that are difficult to do in other languages. 

def clean_strings(strings):
    result = []
    for value in strings:
        value = value.strip()
        value = re.sub(r'[!#?]', '', value)
        value = value.title()
        result.append(value)
    return result

# Another example:
# In [173]: clean_states_strings(states)
# Out[173]:
# ["Alabama", "Georgia", "Georgia", "Georgia", "Florida", "South Carolina", "West Verginia"]

#  An alternative approach that you may find useful is to make a list of the operations you want to 
# apply to a particular set of strings:

def remove_punctuation(value):
    return re.sub(r'[!#?]', '', value)

clean_ops = [str.strip, remove_punctuation, str.title]

def clean_better_strings(strings, ops):
    result = []
    for value in strings:
        for function in ops:
            value = function(value)
        result.append(value)
    return result
#  A more functional pattern like this enables you to easily modify how the strings are transformed at 
# a very high level. The clean_strings function is also now more reusable and generic.

"----------------- Errors and Exception Handling ----------------- "
#  Handling Python errors or exceptions gracefully is an important part of building robust programs.
#  In data analysis applications, many functions only work on certain kinds of input. 
#  As an example, Python’s float function is capable of casting a string to a floating-point number, but 
# fails with ValueError on improper inputs.

def attempt_exception(x):
    try:
        return float(x)
    except:
        return x

# Catch a specific error
def attempt_float(x):
    try:
        return float(x)
    except ValueError: # this line catches only ValueError exceptions
        return x

# Catch multiple errors 
def attempt_another_float(x):
    try:
        return float(x)
    except (TypeError, ValueError): # this line catches both TypeError and ValueError exceptions
        return x


def write_to_file(file_object):
    "Write a short example message to an already-open file."
    file_object.write('This is an example of writing to a file.\n')


def demonstrate_file_exception_handling(path):
    "Show try, except, else, and finally while working with a file."
    f = open(path, 'w')
    try:
        write_to_file(f)
    except OSError:
        print('Failed')
    else:
        print('Succeeded')
    finally:
        f.close()


    "Run the examples in this file."
    # Positional arguments and keyword arguments
    # Each function can have positional arguments and keyword arguments. Keyword arguments are 
    # most commonly used to specify default values or optional arguments.
    print(my_keyword_function(5, 6, z=0.7))
    print(my_keyword_function(3.14, 7, 3.5))
    print(my_keyword_function(10, 20))

    states = [' Alabama!', 'Georgia?', 'Georgia#', 'Georgia!', 'Florida',
              'South Carolina', 'West Verginia']
    print(clean_strings(states))
    print(clean_better_strings(states, clean_ops))

    # Else block:
    # Similarly, you can have code that executes only if the try: block succeeds using else:
    demonstrate_file_exception_handling(Path('function_output.txt'))

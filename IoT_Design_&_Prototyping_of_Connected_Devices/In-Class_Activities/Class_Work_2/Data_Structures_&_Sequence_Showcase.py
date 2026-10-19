"Simple examples of Python lists, tuples, and sequence operations."

import bisect

def print_section(title):
    "Print a consistent heading so each group of examples is easy to read."
    print(f"\n--- {title} ---")


print("Data Structures and Sequences")

# SECTION 1: Creating and changing a list
print_section("Creating and changing a list")
# Lists use square brackets, can contain different types, and are mutable.
a_list = [2, 3, 7, None]
tup = ("foo", "bar", "baz")
b_list = list(tup)  # list() converts the tuple into a new list.
print("Original list:", b_list)

b_list[1] = "peekaboo"  # Assignment changes the item at index 1.
print("After changing index 1:", b_list)

# SECTION 2: Adding and removing elements
print_section("Adding and removing elements")
b_list.append("dwarf")  # append() adds one item to the end.
print("After append:", b_list)

removed_item = b_list.pop(2)  # pop() removes and returns the item at index 2.
print("Item removed by pop(2):", removed_item)
print("After pop:", b_list)

b_list.append("foo")
b_list.remove("foo")  # remove() deletes the first matching value.
print("After removing the first 'foo':", b_list)

print("'dwarf' in list:", "dwarf" in b_list)
print("'dwarf' not in list:", "dwarf" not in b_list)

# SECTION 3: Combining lists
print_section("Combining lists")
# The + operator creates a new list containing both lists.
combined = [4, None, "foo"] + [7, 8, (2, 3)]
print("Using +:", combined)

# extend() adds several items to an existing list in place.
x = [4, None, "foo"]
x.extend([7, 8, (2, 3)])
print("Using extend():", x)

# extend() is useful when combining many lists because it avoids repeatedly
# creating a new list with the + operator.
list_of_lists = [[1, 2], [3, 4], [5, 6]]
everything = []
for chunk in list_of_lists:
    everything.extend(chunk)
print("Several lists extended together:", everything)

# SECTION 4: Sorting
print_section("Sorting")
# sort() changes the list in place. It does not create a separate list.
numbers = [7, 3, 1, 5, 2]
numbers.sort()
print("Sorted numbers:", numbers)

# SECTION 5: Binary search with bisect
print_section("Binary search with bisect")
# bisect works correctly only when the list is already sorted.
c = [1, 2, 2, 2, 3, 4, 7]
print("Insertion position for 2:", bisect.bisect(c, 2))
print("Insertion position for 5:", bisect.bisect(c, 5))

bisect.insort(c, 6)  # Insert 6 while keeping the list sorted.
print("After inserting 6:", c)
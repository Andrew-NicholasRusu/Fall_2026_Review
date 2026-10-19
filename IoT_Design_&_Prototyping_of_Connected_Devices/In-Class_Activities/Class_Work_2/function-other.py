
# def f1():
#     pass

# def f2(name, family,age):
#     if (age > 8):
#         print("You are an adult")

#     elif (19 < age < 65):
#         print("Something else")

#     else:
#         pass
#     return f'{name} : {family}: age={age}'

def f1(li):
    print(li)

def f3(fn, li:list):
    fn(li)

def f3(something, li):
    something(li)

li = ['item1', 'item2', 3, 4, 5, True, False]
f3(f1, li)

def withException(number):
    try:
        if (type(number) == int):
            raise (TypeError)
    except (Exception):
        print(f'This is my exception handling\n')
    finally :
        print('This is showing we successfully handled exception')

withException(10)

# my_var = 'This is the name'

# my_list=[i for i in range(1, 100)]
# for item in my_list:
#     if item == 98:
#         continue
#     print(item)

# for item in range(-50, -200, -10):
    #print(item) 

"--------------------- Data Structure --------------------- "

# list: has all operation []
# set: not duplicate {}
# tuple: immuntable list  ()
# die: key value {}

li = ['orange', 'blue', 'green', 'white',
      'orange', 'blue', 'green', 'white',
      'orange', 'blue', 'green', 'white']

se = {'orange', 'blue', 'green', 'white',
      'orange', 'blue', 'green', 'white',
      'orange', 'blue', 'green', 'white'}

for item in li:
    print(item)

for item in se:
    print(item)

# Tuple example:
tup = ('orange', 'blue', 'green', 'white')
# tup[0]='Red'
li[2] = 'Red'
print(li)

di={0: 'Omid', 
    1: 'Panahi',
    2: 'Computer Science', 
    3:45}
# print(di)

for key,value in di.items():
    print(f'Key is :{key} and value is : {value}')

# Writing (overwrites existing content)
with open ("example.txt", "w") as file_object:
    file_object.write("This will overwrite the file.\n")
    file_object.write("This will overwrite the file.\n")
    file_object.write("This will overwrite the file.\n")
#   file_object.write(f'{i}' for i in range(100, 1000, 3))

with open ('example.txt', 'r') as read_object:
    print(read_object.read())
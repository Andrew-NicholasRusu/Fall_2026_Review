import math

class Circle:
    "Model a simple circle."
    def __init__(self, x =0, y=0, radius=0):
        self.__x = x
        self.__y = y
        self.__radius = radius

    def get_radius(self):
        return self.__radius

    def get_x(self):
        return self.__x

    def get_y(self):
        return self.__y

    def get_area(self):
        return self.__radius ** 2 * math.pi

    def get_perimeter(self):
        return 2 * self.__radius * math.pi

    def contains(self, other_circle):
        # Return if other_circle is conatained wholly in this circle.
        distance = ((self.__x - other_circle.__x) ** 2
                    + (self.__y - other_circle.__y) ** 2)
        distance = math.sqrt(distance)
        return distance + other_circle.__radius <= self.__radius

    def __str__(self):
        return ('x: ' + str(self.__x) + ', y: ' + str(self.__y)
                + ', radius: ' + str(self.__radius))



    
// This program displays the squares of even numbers from 1 to 10.
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            numbers.Add(i);
        }

        var evenNumbers = numbers.Where(n => n % 2 == 0).Select(n => n * n);

        foreach (int num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}
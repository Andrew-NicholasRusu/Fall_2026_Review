using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp7.models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public double Grade { get; set; }

        public string? Email { get; set; }

        public void Display()
        {
            Console.WriteLine(
                $"{Id}: {Name} | Grade: {Grade} | Email: {Email ?? "Not provided"}"
            );
        }
    }
}

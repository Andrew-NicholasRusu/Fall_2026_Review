using ConsoleApp7.models;
using System.Drawing;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------------------------------------
            // 1. Predefined C# types and type inference
            // ------------------------------------------------------------

            int courseCode = 101;
            string courseName = "Introduction to C#";
            double averageGrade = 84.5;
            decimal registrationFee = 125.50m;
            bool courseActive = true;

            var semester = "Fall 2026";
            var maxStudents = 30;

            // String Interpolation
            Console.WriteLine($"Course: {courseCode} - {courseName}");
            Console.WriteLine($"Semester: {semester}");
            Console.WriteLine($"Average Grade: {averageGrade}");
            Console.WriteLine($"Registration Fee: {registrationFee:C}");
            Console.WriteLine($"Active: {courseActive}");
            Console.WriteLine($"Maximum Students: {maxStudents}");

            Console.WriteLine();

            // ------------------------------------------------------------
            // 2. Create objects
            // ------------------------------------------------------------

            Student student1 = new()
            {
                Id = 1,
                Name = "Alice",
                Grade = 88.5,
                Email = "alice@example.com"
            };

            Student student2 = new()
            {
                Id = 2,
                Name = "Bob",
                Grade = 76.0,
                Email = null
            };

            Student student3 = new()
            {
                Id = 3,
                Name = "Charlie",
                Grade = 92.5,
                Email = "charlie@example.com"
            };

            // ------------------------------------------------------------
            // 3. Generic collection + collection expression
            // ------------------------------------------------------------

            List<Student> students =
            [
                student1,
                student2,
                student3
            ];

            Console.WriteLine("=== Students ===");

            foreach (Student student in students)
            {
                student.Display();
            }

            Console.WriteLine();

            // ------------------------------------------------------------
            // 4. Nullable reference type
            // ------------------------------------------------------------

            Console.WriteLine("=== Nullable Reference Type Example ===");

            string? email = student2.Email;

            if (email is not null)
            {
                Console.WriteLine($"Bob's email is {email}");
            }
            else
            {
                Console.WriteLine("Bob does not have an email address.");
            }

            Console.WriteLine();

            // ------------------------------------------------------------
            // 5. Value type semantics
            // ------------------------------------------------------------

            Console.WriteLine("=== Value Type Example ===");

            int firstValue = 10;
            int secondValue = firstValue;

            secondValue = 50;

            Console.WriteLine($"First value: {firstValue}");
            Console.WriteLine($"Second value: {secondValue}");

            Console.WriteLine();

            // ------------------------------------------------------------
            // 6. Reference type semantics
            // ------------------------------------------------------------

            Console.WriteLine("=== Reference Type Example ===");

            Student originalStudent = new()
            {
                Id = 4,
                Name = "David",
                Grade = 80
            };

            Student anotherReference = originalStudent;

            anotherReference.Name = "Daniel";

            Console.WriteLine($"Original reference: {originalStudent.Name}");
            Console.WriteLine($"Second reference: {anotherReference.Name}");

            Console.WriteLine();

            // ------------------------------------------------------------
            // 7. Boxing and unboxing
            // ------------------------------------------------------------

            Console.WriteLine("=== Boxing and Unboxing ===");

            int number = 123;

            // Boxing
            object boxedNumber = number;

            Console.WriteLine($"Boxed value: {boxedNumber}");

            // Unboxing
            int restoredNumber = (int)boxedNumber;

            Console.WriteLine($"Unboxed value: {restoredNumber}");

            Console.WriteLine();

            // ------------------------------------------------------------
            // 9. Pattern matching
            // ------------------------------------------------------------

            Console.WriteLine("=== Pattern Matching ===");

            object value = "C# Programming";

            if (value is string text)
            {
                Console.WriteLine($"The object contains a string: {text}");
                Console.WriteLine($"String length: {text.Length}");
            }

            Console.WriteLine();

            // ------------------------------------------------------------
            // 10. Struct / value type
            // ------------------------------------------------------------

            Console.WriteLine("=== Struct Example ===");

            Point point1 = new()
            {
                X = 10,
                Y = 20
            };

            Point point2 = point1;

            point2.X = 100;

            Console.WriteLine($"Point 1: ({point1.X}, {point1.Y})");
            Console.WriteLine($"Point 2: ({point2.X}, {point2.Y})");

            Console.WriteLine();

            // ------------------------------------------------------------
            // 11. Enum
            // ------------------------------------------------------------

            //Console.WriteLine("=== Enum Example ===");

            //StudentStatus status = StudentStatus.Active;

            //Console.WriteLine($"Student status: {status}");

            //Console.WriteLine();

            // ------------------------------------------------------------
            // 12. Explicit using directive / StringBuilder
            // ------------------------------------------------------------

            Console.WriteLine("=== StringBuilder Example ===");

            StringBuilder report = new();

            report.AppendLine("Student Report");
            report.AppendLine("----------------");

            foreach (Student student in students)
            {
                report.AppendLine(
                    $"{student.Id}: {student.Name} - Grade: {student.Grade}"
                );
            }

            Console.WriteLine(report.ToString());


            // ------------------------------------------------------------
            // 13. Generic collection of value types
            // ------------------------------------------------------------

            List<int> scores = new List<int> { 85, 90, 78, 92, 88 };

            Console.WriteLine("=== Scores ===");

            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }

            Console.WriteLine();


            // ------------------------------------------------------------
            // 14. Simple calculations and interpolation
            // ------------------------------------------------------------

            double total = 0;

            foreach (Student student in students)
            {
                total += student.Grade;
            }

            double calculatedAverage = total / students.Count;

            Console.WriteLine(
                $"Class average: {calculatedAverage:F2}"
            );

            Console.WriteLine();

            // ------------------------------------------------------------
            // 15. Command-line arguments
            // ------------------------------------------------------------

            Console.WriteLine("=== Command-Line Arguments ===");

            Console.WriteLine(
                $"Number of command-line arguments: {args.Length}"
            );

            foreach (string argument in args)
            {
                Console.WriteLine($"Argument: {argument}");
            }

        }
    }
}

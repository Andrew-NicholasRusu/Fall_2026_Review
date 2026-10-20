using CommunityLibrary.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CommunityLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== COMMUNITY LIBRARY ===");
            Console.WriteLine();

            // Part 5: Creating 5 different Book objects
            Book book1 = new Book
            {
                Id = 1,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Price = 10.99,
                PublicationYear = "1925",
                ISBN = "9780743273565",
                Status = BookStatus.Available
            };

            Book book2 = new Book
            {
                Id = 2,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Price = 7.99,
                PublicationYear = "1960",
                ISBN = "9780061120084",
                Status = BookStatus.Available
            };

            Book book3 = new Book
            {
                Id = 3,
                Title = "1984",
                Author = "George Orwell",
                Price = 8.99,
                PublicationYear = "1949",
                ISBN = null,
                Status = BookStatus.Borrowed
            };

            Book book4 = new Book
            {
                Id = 4,
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                Price = 9.99,
                PublicationYear = "1813",
                ISBN = "9780141439518",
                Status = BookStatus.Available
            };

            Book book5 = new Book
            {
                Id = 5,
                Title = "The Catcher in the Rye",
                Author = "J.D. Salinger",
                Price = 6.99,
                PublicationYear = "1951",
                ISBN = "9780316769488",
                Status = BookStatus.Available
            };

            // Part 6: Storing Books in a Generic Collection
            List<Book> books = new List<Book>
            {
                book1, book2, book3, book4, book5
            };

            for (int i = 0; i < books.Count; i++) // Iterating through the list of books and calling the Display() method for each book
            {
                books[i].Display(); // Calling the Display() method
            }

            // Part 7 — Demonstrate Reference-Type Behavior 
            Book originalBook = book1;
            Book referenceBook = originalBook;

            Console.WriteLine($"Original Book title before change: " + originalBook);
            referenceBook.Title = "Flowers for Algernon"; // Modifying the Title of the referenceBook
            Console.WriteLine($"Original Book title After Change : " + originalBook);
            Console.WriteLine($"Reference Book title After Change: " + referenceBook);


            // Part 8: Handle a Nullable ISBN
            foreach (Book book in books) // Iterating through the list of books to check for nullable ISBN
            {

                if (book.ISBN is not null)
                {
                    Console.WriteLine($"ISBN: {book.ISBN}"); // Printing the ISBN if it is not null

                }
                else
                {
                    Console.WriteLine($"ISBN: Not available");
                }
            }

            // Part 9: Demonstrate Boxing and Unboxing:
            Console.WriteLine();
            int numberOfBooks = books.Count; // Example of a value type (int)

            object boxedNumberOfBooks = numberOfBooks; // Boxing
            

            int restoredNumberOfBooks = (int)boxedNumberOfBooks; // Unboxing

            Console.WriteLine($"Original value: {numberOfBooks}"); // Prints the original value of numberOfBooks
            Console.WriteLine($"Boxed value: {boxedNumberOfBooks}"); // Prints the boxed value of numberOfBooks
            Console.WriteLine($"Unboxed value: {restoredNumberOfBooks}"); // Prints the unboxed value of numberOfBooks

            // Part 10: Demonstrate the Unified Type System and Pattern Matching

            object[] items = new object[]
            {
                45, "C# Programming", 29.27m, book1

            };

            foreach (object item in items) // Using a foreach loop to iterate through the items array and perform pattern matching
            {
                if (item is string text)
                {
                    Console.WriteLine($"Detected a string: Length: {text.Length}");
                }
                else if (item is int number)
                {
                    Console.WriteLine($"Found a number: Number: {number}");
                }
                else if (item is decimal decValue)
                {
                    Console.WriteLine($"Detected a Decimal value: {decValue}");
                } 
                else if(item is Book matchedBook)
                {
                    Console.WriteLine($"Detected a Book Object: {matchedBook.Title}");
                }
            }
            
            // Part 11 — Calculating an Inventory Summary:
            Console.WriteLine();
            Console.WriteLine("=== INVENTORY SUMMARY ===");
            Console.WriteLine("pg. 6");

            // Total number of books
            int totalBooks = books.Count;

            // Total value of all books
            double totalValue = 0.0;
            for (int i = 0; i < books.Count; i++)
            {
                totalValue += books[i].Price; // Calculating the total value of all books
            }

            // Average book price (guard against division by zero)
            double averagePrice = totalBooks > 0 ? totalValue / totalBooks : 0.0; 
            // If totalBooks is greater than zero, calculate the average price by dividing totalValue by totalBooks; otherwise, use 0.0.

            Console.WriteLine($"Number of Books: {totalBooks}");
            Console.WriteLine($"Total Inventory Value: {totalValue:C}"); 
            Console.WriteLine($"Average Book Price: {averagePrice:C}");

        }
    }
}

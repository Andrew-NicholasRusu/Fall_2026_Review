using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityLibrary.Models
{
    // Part 2: Creating the Book class
    internal class Book
    {
        // Properties of the Book class
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Should be empty string when the title is unknown
        public string Author { get; set; } = string.Empty; // Should be empty string when the author is unknown
        public double Price { get; set; }
        public string PublicationYear { get; set; }
        public string? ISBN { get; set; } // Should be null when the ISBN is unknown
        public BookStatus Status { get; set; }

        public void Display()
        {
            // Display the details of the book
            Console.WriteLine($"Book ID: {Id}" +
                $"\nTitle: {Title}" +
                $"\nAuthor: {Author}" +
                $"\nPrice: ${Price}" +
                $"\nPublished: {PublicationYear}" +
                $"\nISBN: {ISBN}" +
                $"\nStatus: {Status}");
            Console.WriteLine();
        }
    }
}

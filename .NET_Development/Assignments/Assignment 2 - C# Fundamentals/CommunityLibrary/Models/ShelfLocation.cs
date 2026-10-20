using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityLibrary.Models
{
    // Part 4: Creating a Struct
    public struct ShelfLocation
     {
            public int Aisle // Custom getter and setter for Aisle property
        {
            get; set;
        }
            public int Shelf
        {
            get; set;
        }

        public ShelfLocation(int aisle, int shelf) // Constructor to initialize the ShelfLocation struct
        {
            Aisle = aisle;
            Shelf = shelf;
        }

        public override string ToString() // Override the ToString method to provide a string representation of the ShelfLocation struct
        {
            return $"Aisle: {Aisle} Shelf: {Shelf}";
        }
    }
}

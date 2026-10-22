using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityFoodBankInventorySystem
{
    internal class Food
    {
        public int ItemID
        {
            get; set;
        }
        public string ItemName
        {
            get; set;
        }
        public string Category
        {
            get; set;
        }
        public int Quantity
        {
            get; set;
        }
        // Constructor
        public Food(int ItemID, string ItemName, string Category, int Quantity)
        {
            this.ItemID = ItemID;
            this.ItemName = ItemName;
            this.Category = Category;
            this.Quantity = Quantity;
        }

        public void display()
        {
            Console.WriteLine($"ID: {ItemID}" +
                $"\nItem: {ItemName}" +
                $"\nCategory: {Category}" +
                $"\nQuantity: {Quantity}");
            Console.WriteLine("\n");

            // Display all food items whose quantity is below a specified threshold so staff can identify items that need restocking. 
            if (Quantity <= 10)
            {
                Console.WriteLine("Low on items; needs restocking as soon as possible");
            }
        }
    }
}

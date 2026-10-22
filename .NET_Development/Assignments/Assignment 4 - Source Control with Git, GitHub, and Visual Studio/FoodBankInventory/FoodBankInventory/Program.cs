using CommunityFoodBankInventorySystem;

Console.WriteLine("--- COMMUNITY FOOD BANK INVENTORY SYSTEM ---");
Console.WriteLine(""); // Space

Food food1 = new Food(101, "Canned Beans", "Canned Food", 24);
Food food2 = new Food(102, "Rice", "Dry Food", 15);
Food food3 = new Food(103, "Pasta", "Dry Food", 20);
Food food4 = new Food(104, "Canned Peaches", "Canned Food", 14);
Food food5 = new Food(105, "Beef", "Meat", 8);

List<Food> foods = new List<Food>
{
    food1, food2, food3, food4, food5
};

for (int i = 0; i < foods.Count; i++)
{
    foods[i].display();
}

// Total number of inventory units:
int totalUnits = 0;
foreach (var f in foods)
{
    totalUnits += f.Quantity;
}
Console.WriteLine($"\nTotal inventory units: {totalUnits}");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();

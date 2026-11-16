using Microsoft.Data.SqlClient;

// 1. Connection string -- change Server= to match YOUR SQL Server instance
//    Examples: localhost | .\SQLEXPRESS | (localdb)\MSSQLLocalDB
string connectionString =
    @"Server=(localdb)\MSSQLLocalDB;Integrated Security=True;" +
    "Database=CollegeStoreDB;" +
    "Trusted_Connection=True;" +
    "TrustServerCertificate=True;";

// SELECT statement for all six columns
string query =
    "SELECT ProductID, ProductCode, ProductName, Category, Price, QuantityInStock " +
    "FROM Products";

int count = 0;

try
{
    // using statements 
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(query, connection))
        // make sure resources are closed/disposed automatically
    {
        connection.Open();   // open the connection to CollegeStoreDB

        Console.WriteLine("COLLEGE STORE - PRODUCT LIST");
        Console.WriteLine(new string('=', 78));
        Console.WriteLine("{0,-6}{1,-10}{2,-32}{3,-16}{4,8}{5,6}",
            "ID", "Code", "Product Name", "Category", "Price", "Qty");
        Console.WriteLine(new string('-', 78));

        // Execute the query and read rows one at a time
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string code = reader.GetString(1);
                string name = reader.GetString(2);
                string category = reader.GetString(3);
                decimal price = reader.GetDecimal(4);
                int qty = reader.GetInt32(5);

                Console.WriteLine("{0,-6}{1,-10}{2,-32}{3,-16}{4,8:F2}{5,6}",
                    id, code, name, category, price, qty);

                count++;
            }
        }

        Console.WriteLine(new string('-', 78));
        Console.WriteLine($"Total Products Displayed: {count}");
    }

    Console.WriteLine("Database resources closed successfully.");
}
catch (SqlException ex)
{
    Console.WriteLine("Database error: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

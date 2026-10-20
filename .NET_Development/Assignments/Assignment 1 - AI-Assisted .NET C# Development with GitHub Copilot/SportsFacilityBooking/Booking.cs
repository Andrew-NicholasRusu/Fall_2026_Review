using System;
using System.Collections.Generic;
using System.Linq;

public class Booking
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int FacilityId { get; set; }
    // Duration in hours
    public double DurationHours { get; set; }
    public double BookingCost { get; set; }
    public DateTime BookingDate { get; set; }
    // Create ten bookings containing meaningful sample data.
    // Bookings must reference facilities from Facility.cs by FacilityId.
    public static List<Booking> CreateSampleBookings()
    {
        var facilities = Facility.GetSampleFacilities();

        var bookings = new List<Booking>
        {
            new Booking { Id = 1, CustomerName = "Alice Johnson", FacilityId = 1, DurationHours = 3, BookingDate = DateTime.Today.AddDays(1) },
            new Booking { Id = 2, CustomerName = "Bob Smith", FacilityId = 2, DurationHours = 2, BookingDate = DateTime.Today.AddDays(2) },
            new Booking { Id = 3, CustomerName = "Carla Ruiz", FacilityId = 3, DurationHours = 1, BookingDate = DateTime.Today.AddDays(3) },
            new Booking { Id = 4, CustomerName = "Derek Chan", FacilityId = 4, DurationHours = 4, BookingDate = DateTime.Today.AddDays(4) },
            new Booking { Id = 5, CustomerName = "Emma Williams", FacilityId = 5, DurationHours = 5, BookingDate = DateTime.Today.AddDays(5) },
            new Booking { Id = 6, CustomerName = "Farah Khan", FacilityId = 2, DurationHours = 1.5, BookingDate = DateTime.Today.AddDays(6) },
            new Booking { Id = 7, CustomerName = "George O'Neil", FacilityId = 1, DurationHours = 2.5, BookingDate = DateTime.Today.AddDays(7) },
            new Booking { Id = 8, CustomerName = "Hana Suzuki", FacilityId = 3, DurationHours = 2, BookingDate = DateTime.Today.AddDays(8) },
            new Booking { Id = 9, CustomerName = "Ivan Petrov", FacilityId = 4, DurationHours = 0.5, BookingDate = DateTime.Today.AddDays(9) },
            new Booking { Id = 10, CustomerName = "Julia Martin", FacilityId = 5, DurationHours = 3, BookingDate = DateTime.Today.AddDays(10) }
        };

        // Calculate booking cost using facility hourly rate * duration
        foreach (var b in bookings)
        {
            var facility = facilities.FirstOrDefault(f => f.Id == b.FacilityId);
            if (facility != null)
            {
                b.BookingCost = Math.Round(facility.HourlyRate * b.DurationHours, 2);
            }
            else
            {
                b.BookingCost = 0;
            }
        }

        return bookings;
    }

    // Demonstration: use LINQ Where to identify bookings that last two hours or more
    // and use Select to create a projection with requested information.
    public static void PrintLongBookingsProjection()
    {
        var facilities = Facility.GetSampleFacilities();
        var bookings = CreateSampleBookings();

        // Where: bookings that last two hours or more
        var longBookings = bookings.Where(b => b.DurationHours >= 2);

        // Select: create result containing Customer, Facility, Duration, Total Cost, DurationHours, Date for Booking
        var projection = longBookings.Select(b =>
        {
            var facility = facilities.FirstOrDefault(f => f.Id == b.FacilityId);
            return new
            {
                Customer = b.CustomerName,
                Facility = facility != null ? facility.Name : "Unknown",
                Duration = $"{b.DurationHours} hour(s)",
                TotalCost = b.BookingCost,
                DurationHours = b.DurationHours,
                BookingDate = b.BookingDate.ToString("yyyy-MM-dd")
            };
        });

        Console.WriteLine("Bookings of two hours or more:\n");
        foreach (var item in projection)
        {
            Console.WriteLine($"Customer: {item.Customer}");
            Console.WriteLine($"Facility: {item.Facility}");
            Console.WriteLine($"Duration: {item.Duration}");
            Console.WriteLine($"DurationHours: {item.DurationHours}");
            Console.WriteLine($"Total Cost: ${item.TotalCost}");
            Console.WriteLine($"Date for Booking: {item.BookingDate}");
            Console.WriteLine(new string('-', 40));
        }

        // Use LINQ to sort the bookings by total booking cost from highest to lowest
        var sortedByCostDesc = bookings.OrderByDescending(b => b.BookingCost).ToList();

        Console.WriteLine("\nAll bookings sorted by total cost (high to low):\n");
        foreach (var b in sortedByCostDesc)
        {
            var fac = facilities.FirstOrDefault(f => f.Id == b.FacilityId);
            Console.WriteLine($"Id: {b.Id} | Customer: {b.CustomerName} | Facility: {fac?.Name ?? "Unknown"} | DurationHours: {b.DurationHours} | TotalCost: ${b.BookingCost:F2}");
        }

        // Calculate and display totals using LINQ
        var totalNumberOfBookings = bookings.Count();
        var totalRevenue = bookings.Sum(b => b.BookingCost);
        var averageBookingCost = bookings.Any() ? bookings.Average(b => b.BookingCost) : 0.0;
        var mostExpensiveBooking = bookings.OrderByDescending(b => b.BookingCost).FirstOrDefault();

        Console.WriteLine("\nBooking statistics:\n");
        Console.WriteLine($"Total number of bookings: {totalNumberOfBookings}");
        Console.WriteLine($"Total revenue from all bookings: ${totalRevenue:F2}");
        Console.WriteLine($"Average booking cost: ${averageBookingCost:F2}");

        if (mostExpensiveBooking != null)
        {
            var mf = facilities.FirstOrDefault(f => f.Id == mostExpensiveBooking.FacilityId);
            Console.WriteLine("Most expensive booking:");
            Console.WriteLine($"  Id: {mostExpensiveBooking.Id}");
            Console.WriteLine($"  Customer: {mostExpensiveBooking.CustomerName}");
            Console.WriteLine($"  Facility: {mf?.Name ?? "Unknown"}");
            Console.WriteLine($"  DurationHours: {mostExpensiveBooking.DurationHours}");
            Console.WriteLine($"  TotalCost: ${mostExpensiveBooking.BookingCost:F2}");
            Console.WriteLine($"  BookingDate: {mostExpensiveBooking.BookingDate:yyyy-MM-dd}");
        }
    }

    // Optional: make this runnable as a simple console demo if executed directly
    public static void Main()
    {
        PrintLongBookingsProjection();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey(true);
    }

}


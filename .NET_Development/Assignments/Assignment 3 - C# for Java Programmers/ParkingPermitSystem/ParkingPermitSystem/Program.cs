using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingPermitSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("=== SMART PARKING PERMIT SYSTEM ===");
            Console.WriteLine("====================================");
            List<ParkingPermit> permits = new List<ParkingPermit>
            {
                new ParkingPermit(10101, "Andrew Johnson", "ABC-1234", "Toyota Camry", 45.00, 6, true, PermitStatus.Active, new PermitPeriod(2026, 1, 6)),
                new ParkingPermit(10102, "Maria Gomez", "XYZ-9876", "Honda Civic", 40.00, 12, true, PermitStatus.Active, new PermitPeriod(2026, 3, 12)),
                new ParkingPermit(10103, "Liam Smith", "QWE-4567", "Ford F-150", 60.00, 3, false, PermitStatus.Suspended, new PermitPeriod(2026, 7, 29)),
                new ParkingPermit(10104, "Aisha Khan", "PLT-2024", "Tesla Model 3", 75.00, 1, true, PermitStatus.Expired, new PermitPeriod(2026, 2, 11)),
                new ParkingPermit(10105, "Chen Li", "HJK-3301", "Nissan Leaf", 35.50, 24, true, PermitStatus.PendingApproval, new PermitPeriod(2024, 6, 23))
            };

            // Part I and G - Display information for all 5 permits
            Console.WriteLine(" Registered Municipal Permits");
            double totalMuniccipalRevenue = 0.0;
            foreach(var permit in permits)
            {
                permit.DisplayPermitInfo();
                totalMuniccipalRevenue += permit.TotalPermitCost();
            }
            Console.WriteLine($"Projected Aggregate Revenue: ${totalMuniccipalRevenue}\n");

            Console.WriteLine("====================================");
            Console.WriteLine("Part C: Property Validation Testing"); 
            Console.WriteLine("====================================");

            ParkingPermit testPermit = permits[0];
            Console.WriteLine($"Testing Target: Permit {testPermit.PermitID} - Current Fee: ${testPermit.MonthlyFee}");

            Console.WriteLine("Assigning Invalid Monthly Fee: -$30.00");
            testPermit.MonthlyFee = -30.00;
            Console.WriteLine($"Resulting Monthly Fee Value: ${testPermit.MonthlyFee} ");

            Console.WriteLine("Assigning Valid Monthly Fee: $55.00");
            testPermit.MonthlyFee = 55.00;
            Console.WriteLine($"Resulting Monthly Fee Value: ${testPermit.MonthlyFee} - Successfully Updated");
            Console.WriteLine("\n");

            Console.WriteLine("Assigning Invalid Duration of 36 Months - Maximum allowed is 24 months only:");
            testPermit.NumberOfMonths = 36;
            Console.WriteLine($"Resulting Number of Months Value: ${testPermit.NumberOfMonths}");

            Console.WriteLine("Assigning Valid Duration of 12 months:");
            testPermit.NumberOfMonths = 12;
            Console.WriteLine($"Resulting  Number of Months Value: ${testPermit.NumberOfMonths} - Successfully Updated");


            Console.WriteLine($"Updated Total Cost for Permit: {testPermit.PermitID} : ${testPermit.TotalPermitCost()}");

            Console.WriteLine("====================================");
            Console.WriteLine("Application Executed Completed");
            Console.WriteLine("====================================");
        }
        
    }
}

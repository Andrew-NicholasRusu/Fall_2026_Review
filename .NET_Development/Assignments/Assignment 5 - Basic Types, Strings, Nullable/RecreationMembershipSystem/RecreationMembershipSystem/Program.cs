using System;
using System.Collections.Generic;
using System.Text;
using RecreationMembershipSystem;

namespace RecreationMembershipSystem 
{
    internal class Program
    {
        static void Main()
        {
            // Create activity combinations using bitwise OR
            var acts1 = Activities.Swimming | Activities.Fitness;
            var acts2 = Activities.Yoga | Activities.Fitness | Activities.Basketball;
            var acts3 = Activities.Basketball;
            var acts4 = Activities.None;
            var acts5 = Activities.Swimming | Activities.Yoga;

            acts1 |= Activities.Yoga; // another activity using |=.

            // Create at least five different members demonstrating different
            // membership types, monthly fees, locker assignments and activities.
            // One member has no locker (locker number 0) and several have multiple activities.
            var member1 = new Member(1, "Alice Smith", 28, "alice.smith@gmail.com", 49.99m,
                MembershipType.Standard, 101, acts1);

            var member2 = new Member(2, "Bob Johnson", 21, "bob.johnson@gmail.com", 29.99m,
                MembershipType.Student, null, acts2); // no locker

            var member3 = new Member(3, "Carol Lee", 67, "carol.lee@outlook.com", 34.50m,
                MembershipType.Senior, 205, acts3);

            var member4 = new Member(4, "David Kim", 40, "david.kim@hotmail.com", 74.00m,
                MembershipType.Family, 310, acts4);

            var member5 = new Member(5, "Evelyn Martinez", 33, "evelyn.m@hotmail.com", 59.95m,
                MembershipType.Standard, 150, acts5);

            List<Member> members = new List<Member>
            {
                member1, member2, member3, member4, member5
            };

            // Demonstrate checking an activity using &.
            bool participatesInSwimming = (member1.Activities & Activities.Swimming) != 0;

            Console.WriteLine($"{member1.FullName} participates in swimming: " +
                            $"{participatesInSwimming}");
            Console.WriteLine();

            // Display each member's basic information.
            foreach (Member member in members)
            {
                DisplayMember(member);
                Console.WriteLine(new string('-', 40));
            }

            // Calculte total and average fees.
            decimal totalMonthlyRevenue = 0m;

            foreach (Member member in members)
            {
                totalMonthlyRevenue += member.MonthlyFee;
            }

            decimal averageMonthlyFee = totalMonthlyRevenue / members.Count;

            Console.WriteLine($"Total monthly revenue: {totalMonthlyRevenue:C}");
            Console.WriteLine($"Average monthly fee: {averageMonthlyFee:C}");
            Console.WriteLine();

            // Process a member name entered by the user.
            Console.WriteLine("Please enter a member's full name: ");

            string input = Console.ReadLine() ?? string.Empty;

            // Trim extra whitespace.
            string trimmedName = input.Trim();

            // Split the name into separate parts.
            string[] nameParts = trimmedName.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries);

            // Join the cleaned parts back together.
            string cleanedName = String.Join(" ", nameParts);

            // Demonstrate toUpper().
            string uppercaseName = cleanedName.ToUpper();

            Console.WriteLine($"Cleaned name: {cleanedName}");
            Console.WriteLine($"Uppercase name: {uppercaseName}");

            // Compare names without considering capitalization.
            Member? matchingMember = members.Find(member => string.Equals(member.FullName, cleanedName, StringComparison.OrdinalIgnoreCase));

            if (matchingMember != null)
            {
                Console.WriteLine($"Member found: {matchingMember.FullName}");
            }
            else
            {
                Console.WriteLine($"No member was found for: {cleanedName}");
            }
            Console.WriteLine(); // Space

            // Generate the membership report using StringBuilder.
            StringBuilder report = new StringBuilder();

            report.AppendLine("COMMUNITY RECREATION CENTRE");
            report.AppendLine("MEMBERSHIP REPORT");
            report.AppendLine(new string('=', 35));

            foreach (Member member in members)
            {
                string lockerText = member.LockerNumber.HasValue ? member.LockerNumber.Value.ToString() : "Not Assigned";

                report.AppendLine($"Member: {member.FullName}");
                report.AppendLine($"Membership: {member.MembershipType}");
                report.AppendLine($"Monthly Fee: {member.MonthlyFee:C}");
                report.AppendLine($"Activites: {GetActivityText(member.Activities)}");
                report.AppendLine($"Locker: {lockerText}");
                report.AppendLine();
            }

            report.AppendLine($"Total Monthly Revenue: {totalMonthlyRevenue:C}");
            report.AppendLine($"Average Monthly Fee: {averageMonthlyFee:C}");

            // Convert StringBuilder to a string before displaying it.
            string completedReport = report.ToString();

            Console.WriteLine(completedReport);
        }

        private static void DisplayMember (Member member)
        {
            string lockerText = member.LockerNumber.HasValue ? member.LockerNumber.Value.ToString() : "Not Assigned";

            Console.WriteLine($"Member ID: {member.MemberID}");
            Console.WriteLine($"Name: {member.FullName}");
            Console.WriteLine($"Age: {member.Age}");
            Console.WriteLine($"Email: {member.Email}");
            Console.WriteLine($"Membership: {member.MembershipType}");
            Console.WriteLine($"Activities: {GetActivityText(member.Activities)}");
            Console.WriteLine($"Locker; {lockerText}");
        }

        private static string GetActivityText(Activities activities)
        {
            if (activities == Activities.None)
            {
                return "None";
            }

            List<string> activityNames = new List<string>();

            if ((activities & Activities.Swimming) != 0)
            {
                activityNames.Add("Swimming");
            }
            if ((activities & Activities.Fitness) != 0)
            {
                activityNames.Add("Fitness");
            }
            if ((activities & Activities.Yoga) != 0)
            {
                activityNames.Add("Yoga");
            }
            if ((activities & Activities.Basketball) != 0)
            {
                activityNames.Add("Basketball");
            }

            return String.Join(", ", activityNames);
        }
    }
}

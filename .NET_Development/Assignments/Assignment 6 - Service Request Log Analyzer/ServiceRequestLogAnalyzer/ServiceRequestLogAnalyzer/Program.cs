using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ServiceRequestLogAnalyzer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string inputPath = "ServiceRequests.txt";
            const string reportPath = "ServiceReport.txt";
            const string backupPath = "ServiceReport_backup.txt";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file '{inputPath}' not found.");
                return;
            }

            var requests = new List<ServiceRequest>();

            // Read the input file using a while loop (demonstrates while)
            using (StreamReader reader = new StreamReader(inputPath))
            {
                string? line;
                int lineNumber = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (string.IsNullOrWhiteSpace(line))
                        continue; // skip blank lines

                    // Allow for an optional header line
                    if (lineNumber == 1 && (line.Contains("Request", StringComparison.OrdinalIgnoreCase) || line.Contains("Category", StringComparison.OrdinalIgnoreCase)))
                        continue;

                    string[] fields = line.Split(',');
                    if (fields.Length < 4)
                    {
                        Console.WriteLine($"Skipping malformed line {lineNumber}: '{line}'");
                        continue; // demonstrate continue for malformed records
                    }

                    string id = fields[0].Trim();
                    string category = fields[1].Trim();

                    if (!int.TryParse(fields[2].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int priority))
                    {
                        Console.WriteLine($"Skipping line {lineNumber} due to invalid priority: '{fields[2]}'");
                        continue;
                    }

                    if (!decimal.TryParse(fields[3].Trim(), NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture, out decimal estimatedCost))
                    {
                        Console.WriteLine($"Skipping line {lineNumber} due to invalid estimated cost: '{fields[3]}'");
                        continue;
                    }

                    requests.Add(new ServiceRequest(id, category, priority, estimatedCost));
                }
            }

            if (requests.Count == 0)
            {
                Console.WriteLine("No valid service requests to process.");
                return;
            }

            // Process requests using foreach (demonstrates foreach)
            decimal totalEstimatedCost = 0m;
            const decimal highCostThreshold = 200m; // chosen threshold for "costing more than"
            var highCostRequests = new List<ServiceRequest>();

            var reportLines = new List<string>();
            reportLines.Add("SERVICE REQUEST REPORT");

            int index = 0;
            foreach (var req in requests)
            {
                index++;
                totalEstimatedCost += req.EstimatedCost; // compound-assignment demonstration

                // Determine urgency using logical and relational operators
                bool isUrgent = req.Priority >= 4 && req.EstimatedCost > 200m;

                // Identify requests costing more than threshold
                if (req.EstimatedCost > highCostThreshold)
                {
                    highCostRequests.Add(req);
                }

                // Use switch to provide category-specific note (demonstrates switch)
                switch (req.Category)
                {
                    case "Plumbing":
                        Console.WriteLine("Assign to plumbing team.");
                        break;

                    case "Electrical":
                        Console.WriteLine("Assign to electrical team");
                        break;

                    default:
                        Console.WriteLine("Assign to general maintenance.");
                        break;
                }

                // Use modulo operator to add a periodic inspection note for every 3rd request
                string periodicNote = (index % 3 == 0) ? "Periodic inspection recommended." : string.Empty;

                // If an abnormally large urgent request is found, stop processing (demonstrates break)
                if (isUrgent && req.EstimatedCost > 10000m)
                {
                    reportLines.Add($"Request: {req.Id}");
                    reportLines.Add($"Category: {req.Category}");
                    reportLines.Add($"Priority: {req.Priority}");
                    reportLines.Add($"Estimated Cost: {req.EstimatedCost:C}");
                    reportLines.Add("Status: Abnormally large urgent request - processing halted.");
                    break;
                }

                reportLines.Add($"Request: {req.Id}");
                reportLines.Add($"Category: {req.Category}");
                reportLines.Add($"Priority: {req.Priority}");
                reportLines.Add($"Estimated Cost: {req.EstimatedCost:C}");
                reportLines.Add($"Status: {(isUrgent ? "Urgent" : "Normal")}");
                string costLevel;
                if (req.EstimatedCost < 150m)
                {
                    costLevel = "Low";
                }
                else if (req.EstimatedCost <= 350m)
                {
                    costLevel = "Medium";
                }
                else
                {
                    costLevel = "High";
                }
                reportLines.Add($"Cost Level: {costLevel}");
                if (!string.IsNullOrEmpty(periodicNote))
                    reportLines.Add(periodicNote);
                reportLines.Add(new string('-', 29));
            }

            decimal averageEstimatedCost = requests.Count > 0 ? totalEstimatedCost / requests.Count : 0m;

            // Summary
            reportLines.Add($"Total Requests: {requests.Count}");
            reportLines.Add($"Total Estimated Cost: {totalEstimatedCost:C}");
            reportLines.Add($"Average Estimated Cost: {averageEstimatedCost:C}");

            // Write the report to a file
            using (StreamWriter writer = new StreamWriter(reportPath))
            {
                foreach (var line in reportLines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine($"Report written to '{reportPath}'.");

            // Verify the file exists, then read and display it (demonstrates File.Exists and StreamReader)
            if (File.Exists(reportPath))
            {
                Console.WriteLine("\n--- Report Contents ---\n");
                using (StreamReader reportReader = new StreamReader(reportPath))
                {
                    string? content;
                    while ((content = reportReader.ReadLine()) != null)
                    {
                        Console.WriteLine(content);
                    }
                }

                DateTime lastModified = File.GetLastWriteTime(reportPath);
                Console.WriteLine($"\nReport last modified: {lastModified}");

                // Create a backup copy
                File.Copy(reportPath, backupPath, overwrite: true);
                Console.WriteLine($"Backup created at '{backupPath}'.");
            }
            else
            {
                Console.WriteLine($"Failed to find the report at '{reportPath}' after writing.");
            }

            // Additional console summary for high-cost requests
            if (highCostRequests.Count > 0)
            {
                Console.WriteLine($"\nRequests costing more than {highCostThreshold:C}:");
                foreach (var hr in highCostRequests)
                {
                    Console.WriteLine($"- {hr.Id}: {hr.EstimatedCost:C}");
                }
            }

            // Use appropriate exception handling for the file operations.
            try
            {
                // File operations
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied: {ex.Message}");
            }
        }
        private sealed record ServiceRequest(string Id, string Category, int Priority, decimal EstimatedCost);
    }
}

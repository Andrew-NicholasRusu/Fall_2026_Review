using ParkingPermitSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingPermitSystem
{

    // Part A: Creating the ParkingPermit Class
    class ParkingPermit : IFeeCalculator // implements IFeeCalculator

    {
        private double _monthlyFee;
        private int _numberOfMonths;
        // Simple auto-properties
        public int PermitID
        {
            get; set;
        }
        public string OwnerName
        {
            get; set;
        }
        public string VehiclePlate
        {
            get; set;
        }
        public string VehicleType
        {
            get; set;
        }

        public PermitStatus Status
        {
            get; set;
        }
        public PermitPeriod Period { get; set; }


        public double MonthlyFee
        {
            get => _monthlyFee;
            set
            {
                if (value >= 0)
                {
                    _monthlyFee = value;
                }
                else
                {
                    Console.WriteLine($"Monthly Fee cannot be negative.");
                }
            }
        }

        public int NumberOfMonths
        {
            get => _numberOfMonths;
            set
            {
                if (value >= 1 && value <= 24)
                {
                    _numberOfMonths = value;
                }
                else
                {
                    Console.WriteLine($"Duration must be between 1 and 24 months.");
                }
            }
        }


        // Part B: Constructor & Objects
        // Default Contstructor
        public ParkingPermit()
        {
            OwnerName = string.Empty;
            VehiclePlate = string.Empty;
            VehicleType = "Standard";
            Status = PermitStatus.PendingApproval;
        }

        public ParkingPermit(int permitID, string ownerName, string vehiclePlate, string vehicleType,
                             double monthlyFee, int numberOfMonths, bool isResident, PermitStatus permitStatus, PermitPeriod period)
        {
            PermitID = permitID;
            OwnerName = ownerName;
            VehiclePlate = vehiclePlate;
            VehicleType = vehicleType;
            MonthlyFee = monthlyFee; // validated by property
            Status = permitStatus;
            Period = period;
            MonthlyFee = monthlyFee;
            NumberOfMonths = numberOfMonths;
            isResident = isResident;
        }

        public double TotalPermitCost()
        {
            return MonthlyFee * NumberOfMonths;
        }

        public bool IsPermitCurrentlyValid()
        {
            bool isActive = (Status == PermitStatus.Active);
            bool hasValidDuration = (NumberOfMonths > 0);
            bool hasValidFee = (MonthlyFee > 0.0);

            if (isActive && hasValidDuration && hasValidFee)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Part I: Displaying Permit Information

        public void DisplayPermitInfo()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Permit ID : {PermitID}");
            Console.WriteLine($"Owner name : {OwnerName} ");
            Console.WriteLine($"Vehicle Plate : {VehiclePlate} [{VehicleType}]");
            Console.WriteLine($"Permit  Period : {Period}");
            Console.WriteLine($"Status : {Status}");
            Console.WriteLine($"Monthly Fee : ${MonthlyFee}");
            Console.WriteLine($"Duration : {NumberOfMonths} month(s)");
            Console.WriteLine($"Total Cost : ${TotalPermitCost()}");
            if (IsPermitCurrentlyValid())
            {
                Console.WriteLine($"Active Standing : VALID");
            }
            else
            {
                Console.WriteLine($"Active Standing : INVALID - Need Action");
            }

            Console.WriteLine("--------------------------------");
        }
    }
}


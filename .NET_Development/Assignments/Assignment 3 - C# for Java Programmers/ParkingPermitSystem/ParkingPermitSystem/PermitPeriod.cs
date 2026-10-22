using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingPermitSystem
{
    // Part E: Creating and Using a Struct
    public struct PermitPeriod
    {
        public int StartYear
        {
            get; set;
        }
        public int StartMonth
        {
            get; set;
        }
        public int DurationInMonths
        {
            get; set;
        }

        public PermitPeriod(int StartYear, int StartMonth, int DurationInMonths)
        {
            this.StartYear = StartYear;
            this.StartMonth = StartMonth;
            this.DurationInMonths = DurationInMonths;
        }
    }
}

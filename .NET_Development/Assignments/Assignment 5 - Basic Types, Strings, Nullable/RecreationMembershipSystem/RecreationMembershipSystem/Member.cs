using System;
using System.Collections.Generic;
using System.Text;

namespace RecreationMembershipSystem
{
    internal class Member
    {
        public int MemberID
        {
            get; set;
        }
        public string FullName
        {
            get; set;
        }
        public int Age
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public decimal MonthlyFee
        {
            get; set;
        }
        public MembershipType MembershipType
        {
            get; set;
        }
        public int? LockerNumber
        {
            get; set;
        }
        public Activities Activities
        {
            get; set;
        }

        public Member (int MemberID, string FullName, int Age, string Email, 
            decimal MonthlyFee, MembershipType MembershipType, int? LockerNumber, Activities Activities)
        {
            this.MemberID = MemberID;
            this.FullName = FullName;
            this.Age = Age;
            this.Email = Email;
            this.MonthlyFee = MonthlyFee;
            this.MembershipType = MembershipType;
            this.LockerNumber = LockerNumber;
            this.Activities = Activities;
        }

        public override string ToString()
        {
            string lockerText = LockerNumber.HasValue
                ? LockerNumber.Value.ToString()
                : "Not Assigned";
        
            return  $"Member ID: {MemberID}" +
                    $"\nName of the Trainer: {FullName}" +
                    $"\nAge of the Trainer: {Age}" +
                    $"\nTrainer's Email: {Email}" +
                    $"\nTrainer's MonthlyFee: {MonthlyFee}" +
                    $"\nType of Membership: {MembershipType}" +
                    $"\nTrainer's Locker Number:" + 
                    $"\nTrainer's Selected Activities: {Activities}";
        }
    }
}

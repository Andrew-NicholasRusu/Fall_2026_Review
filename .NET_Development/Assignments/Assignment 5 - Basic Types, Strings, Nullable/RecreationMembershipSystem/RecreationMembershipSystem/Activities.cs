using System;
using System.Collections.Generic;
using System.Text;

namespace RecreationMembershipSystem
{
    [Flags]
    public enum Activities
    {
        None = 0,
        Swimming = 1,
        Fitness = 2,
        Yoga = 4,
        Basketball = 8
    }
}

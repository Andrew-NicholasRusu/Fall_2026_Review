using System.Collections.Generic;

public class Facility
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    // A short programmatic code to reference the facility from other classes (e.g., Booking)
    public string Code { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public double HourlyRate { get; set; }
    public bool IsAvailable { get; set; }
    public string Location { get; set; } = string.Empty;
    // Returns five meaningful sample facilities for booking using simple named variables
    public static List<Facility> GetSampleFacilities()
    {
        var conf = new Facility
        {
            Id = 1,
            Name = "Main Conference Room",
            Code = "CONF_MAIN",
            Type = "Conference",
            HourlyRate = 75.00,
            IsAvailable = true,
            Location = "Building A - Floor 1"
        };

        var tennis = new Facility
        {
            Id = 2,
            Name = "West Tennis Court",
            Code = "TENN_WEST",
            Type = "Sports/Tennis",
            HourlyRate = 25.00,
            IsAvailable = false,
            Location = "Outdoor Complex - Court 2"
        };

        var swim = new Facility
        {
            Id = 3,
            Name = "Aquatics Lane 3",
            Code = "SWIM_L3",
            Type = "Swimming",
            HourlyRate = 15.50,
            IsAvailable = true,
            Location = "Recreation Center - Pool"
        };

        var desk = new Facility
        {
            Id = 4,
            Name = "Hot Desk - Open Workspace",
            Code = "WORK_HOTDESK",
            Type = "Workspace",
            HourlyRate = 10.00,
            IsAvailable = true,
            Location = "Building B - 2nd Floor"
        };

        var aud = new Facility
        {
            Id = 5,
            Name = "Auditorium Hall",
            Code = "AUD_HALL",
            Type = "Event/Auditorium",
            HourlyRate = 200.00,
            IsAvailable = false,
            Location = "Main Campus - Auditorium"
        };

        return new List<Facility> { conf, tennis, swim, desk, aud };
    }
}

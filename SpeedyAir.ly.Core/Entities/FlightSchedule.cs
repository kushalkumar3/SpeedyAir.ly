namespace SpeedyAir.ly.Core.Entities
{
    public class FlightSchedule
    {
        public string? Id { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
    }

    public class FlightScheduleJson
    {
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
    }
}
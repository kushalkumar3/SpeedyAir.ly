using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedyAir.ly.Core.Entities
{
    public class Order
    {
        public string? Id { get; set; }
        public string? Destination { get; set; }
        public FlightSchedule? FlightSchedule { get; set; }
    }
}
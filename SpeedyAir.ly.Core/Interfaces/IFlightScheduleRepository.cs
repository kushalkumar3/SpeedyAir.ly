using SpeedyAir.ly.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Core.Interfaces
{
    public interface IFlightScheduleRepository
    {
        Task<bool> LoadFlightSchedule(List<FlightSchedule> flightSchedules);
        Task<List<FlightSchedule>> GetFlightSchedule();
    }
}

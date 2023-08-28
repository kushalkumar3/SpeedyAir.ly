using SpeedyAir.ly.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Core.Interfaces
{
    public interface IFlightScheduleService
    {
        Task<bool> LoadFlightSchedule(string path);
        Task<List<FlightSchedule>> GetFlightSchedule();
    }
}

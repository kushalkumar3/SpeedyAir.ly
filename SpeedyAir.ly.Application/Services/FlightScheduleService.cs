using Newtonsoft.Json;
using SpeedyAir.ly.Core.Entities;
using SpeedyAir.ly.Core.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Application.Services
{
    public class FlightScheduleService : IFlightScheduleService
    {
        private readonly IFlightScheduleRepository _flightRepo;
        public FlightScheduleService(IFlightScheduleRepository flightScheduleRepository)
        {
            _flightRepo = flightScheduleRepository;
        }

        public Task<List<FlightSchedule>> GetFlightSchedule()
        {
            return _flightRepo.GetFlightSchedule();
        }

        Task<bool> IFlightScheduleService.LoadFlightSchedule(string filePath)
        {
            List<FlightSchedule> FlightSchedules = new();
            
            string json = File.ReadAllText(filePath);


            var items = JsonConvert.DeserializeObject<dynamic>(json);
            if (items != null)
            {
                foreach (dynamic obj in items)
                {
                    foreach (dynamic ob in obj.Value)
                    {

                        FlightSchedule flightSchedule = new();
                        flightSchedule.Id = ob.Name;

                        flightSchedule.Departure = ob.Value.Departure;
                        flightSchedule.Arrival = ob.Value.Arrival;
                        FlightSchedules.Add(flightSchedule);
                    }
                }
            }

            return _flightRepo.LoadFlightSchedule(FlightSchedules);
        }
    }
}
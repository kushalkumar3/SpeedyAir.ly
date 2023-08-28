using Newtonsoft.Json;
using SpeedyAir.ly.Core.Entities;
using SpeedyAir.ly.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Infrastracture.Repositories
{
    public class FlightScheduleRepository : IFlightScheduleRepository
    {

        Task<List<FlightSchedule>> IFlightScheduleRepository.GetFlightSchedule()
        {
            List<FlightSchedule>? flightSchedules = new List<FlightSchedule>();
            string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../../../SpeedyAir.ly.Infrastracture/LoadedFlightSchedule/flight-schedule.json"));
            string json = File.ReadAllText(filePath);
            flightSchedules = JsonConvert.DeserializeObject<List<FlightSchedule>>(json);
            if (flightSchedules != null)
            {
                return Task.FromResult(flightSchedules);
            }
            else
            {
                return Task.FromResult(new List<FlightSchedule>());
            }
        }

        Task<bool> IFlightScheduleRepository.LoadFlightSchedule(List<FlightSchedule> flightSchedules)
        {
            var json = JsonConvert.SerializeObject(flightSchedules);
            File.WriteAllText(@"../../../../SpeedyAir.ly.Infrastracture/LoadedFlightSchedule/flight-schedule.json", JsonConvert.SerializeObject(flightSchedules));
            return Task.FromResult(true);
        }


    }
}
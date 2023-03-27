// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpeedyAir.ly.Core.Interfaces;
using SpeedyAir.ly.Infrastracture.Repositories;
using SpeedyAir.ly.Application.Services;
using SpeedyAir.ly.Application.Interfaces;
using System;
using System.IO;
using SpeedyAir.ly.Core.Entities;
using System.Threading.Tasks;

public class InitPortal
{  
    public static async Task LoadOrderSchedulePortalAsync(IFlightScheduleService _flightService,IOrderService _orderService, IScheduleOrderService _scheduleOrderService)
    {
       
        int input = Console.Read();
        input = (int)char.GetNumericValue(Convert.ToChar(input));
        if (input == 1)
        {
            string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory + "../../../../Data/FlightSchedule.json"));
            var result = await _flightService.LoadFlightSchedule(filePath);
            if(result)
            {
                Console.WriteLine("Flight schedule loaded successfully.");
            }
        }
        else if (input == 2)
        {
            var flightScheduleList = await _flightService.GetFlightSchedule();
            foreach(FlightSchedule flightSchedule in flightScheduleList)
            {
                Console.WriteLine("{0}: {1} to {2}", flightSchedule.Id, flightSchedule.Departure, flightSchedule.Arrival);
            }

        }
        else if (input == 3)
        {
            var scheduleOrders = await _scheduleOrderService.GetScheduleOrders(20);
            foreach (Order order in scheduleOrders)
            {
                if (order.FlightSchedule != null)
                {
                    Console.WriteLine("order: {0}, flightNumber: {1}, departure: {2}, arrival: {2}", order.Id, order.FlightSchedule.Departure, order.FlightSchedule.Arrival);
                }
                else
                {
                    Console.WriteLine("order: {0}, flightNumber: not scheduled", order.Id);
                }
            }
        }
        input = 0;
               
    }

}
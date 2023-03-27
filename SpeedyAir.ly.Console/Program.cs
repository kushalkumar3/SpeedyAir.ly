// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpeedyAir.ly.Core.Interfaces;
using SpeedyAir.ly.Infrastracture.Repositories;
using SpeedyAir.ly.Application.Services;
using SpeedyAir.ly.Application.Interfaces;
using System;

public class Program
{
    public static async System.Threading.Tasks.Task Main(string[] args)
    {
        //setup our DI
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IOrderRepository, OrderRepository>()
            .AddSingleton<IOrderService, OrderService>()
            .AddSingleton<IFlightScheduleService, FlightScheduleService>()
            .AddSingleton<IFlightScheduleRepository, FlightScheduleRepository>()
            .AddSingleton<IScheduleOrderService, ScheduleOrderService>()
            .BuildServiceProvider();

        var _flightService = serviceProvider.GetService<IFlightScheduleService>();
        var _orderService = serviceProvider.GetService<IOrderService>();
        var _scheduleOrderService = serviceProvider.GetService<IScheduleOrderService>();
        Console.WriteLine("Schedule orders portal!");
        Console.WriteLine("Press 1 to load flight schedule.");
        Console.WriteLine("Press 2 to list out loaded flight schedule.");
        Console.WriteLine("Press 3 to load and list out loaded orders.");
        //do the actual work here
        while (true){
            await InitPortal.LoadOrderSchedulePortalAsync(_flightService, _orderService, _scheduleOrderService);
        }
    }
}
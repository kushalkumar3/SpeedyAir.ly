using SpeedyAir.ly.Application.Interfaces;
using SpeedyAir.ly.Core.Entities;
using SpeedyAir.ly.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Application.Services
{
    public class ScheduleOrderService : IScheduleOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IFlightScheduleRepository _flightScheduleRepo;

        public ScheduleOrderService(IOrderRepository orderRepository, IFlightScheduleRepository flightScheduleRepository)
        {
            _orderRepo = orderRepository;
            _flightScheduleRepo = flightScheduleRepository;
        }

        public Task<List<Order>> GetScheduleOrders(int maxOrdersPerFlight)
        {
            List<Order> orders = _orderRepo.GetOrders().Result;
            List<FlightSchedule> flightSchedules = _flightScheduleRepo.GetFlightSchedule().Result;
            foreach (FlightSchedule fs in flightSchedules)
            {
                orders = ScheduleOrder(orders, fs, maxOrdersPerFlight);
            }
            return Task.FromResult(orders);
        }

        private List<Order> ScheduleOrder(List<Order> orders, FlightSchedule flightSchedule, int maxOrdersPerFlight)
        {
            int counter = 0;
            foreach (Order order in orders.Where(c => c.Destination == flightSchedule.Arrival && c.FlightSchedule == null).ToList())
            {
                if (counter < maxOrdersPerFlight)
                {
                    order.FlightSchedule = flightSchedule;
                }                
                counter++;
            }
            return orders;
        }
    }
}
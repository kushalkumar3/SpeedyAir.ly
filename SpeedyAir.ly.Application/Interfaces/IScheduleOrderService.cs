using SpeedyAir.ly.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Application.Interfaces
{
    public interface IScheduleOrderService
    {
        Task<List<Order>> GetScheduleOrders(int maxOrdersPerFlight);        
    }
}
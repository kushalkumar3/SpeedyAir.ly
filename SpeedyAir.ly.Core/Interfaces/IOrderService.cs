using SpeedyAir.ly.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Core.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();  
    }
}

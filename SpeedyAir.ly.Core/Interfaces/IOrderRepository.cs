using SpeedyAir.ly.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();        
    }
}

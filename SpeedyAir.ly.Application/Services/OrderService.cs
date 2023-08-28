using SpeedyAir.ly.Core.Entities;
using SpeedyAir.ly.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }
        
        Task<List<Order>> IOrderService.GetOrders()
        {
            return _orderRepo.GetOrders();
        }
    }
}
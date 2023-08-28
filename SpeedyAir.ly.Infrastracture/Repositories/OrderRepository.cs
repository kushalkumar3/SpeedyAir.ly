using SpeedyAir.ly.Core.Entities;
using SpeedyAir.ly.Core.Interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System;

namespace SpeedyAir.ly.Infrastracture.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        Task<List<Order>> IOrderRepository.GetOrders()
        {
            List<Order> Orders = new List<Order>();
            string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../../../SpeedyAir.ly.Infrastracture/SeedFiles/coding-assigment-orders.json"));
            string json = File.ReadAllText(filePath);
            var items = JsonConvert.DeserializeObject<dynamic>(json);
            if (items != null)
            {
                foreach (dynamic obj in items)
                {
                    Order order = new();
                    order.Id = obj.Name;
                    order.Destination = obj.Value.destination.ToString();
                    Orders.Add(order);
                }
            }
            return Task.FromResult(Orders);
        }

    }
}
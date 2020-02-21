using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;

namespace OrderService.Repositories
{
   public interface IOrderRepository
    {
        List<Orders> GetAllOrders();
        Orders GetById(string id);
        void AddOrders(Orders obj);
        void DeleteOrders(string id);
        void UpdateOrders(Orders obj);
    }
}

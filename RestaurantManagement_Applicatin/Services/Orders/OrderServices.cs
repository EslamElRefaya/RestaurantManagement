using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.Orders
{
   public class OrderServices: IOrderServices
    {
        private readonly IRestaurantManagementRepository<Order> _orderRepository;

        public OrderServices(IRestaurantManagementRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task AddOrderService(Order order)
        {
            await _orderRepository.AddItemRepo(order);
        }

        public async Task DeleteOrderService(Order order)
        {
            await _orderRepository.DeleteItemRepo(order);
        }

        public Task<IEnumerable<Order>> GetAllOrdersService()
        {
           return _orderRepository.GetAllItemsRepo();
        }

        public async Task<Order> GetOrderByIdService(int id)
        {
           return await _orderRepository.GetItemByIdRepo(id);
        }

        public async Task UpdateOrderService(Order order)
        {
            await _orderRepository.UpdateItemRepo(order);
        }
    }
}

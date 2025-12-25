using RestaurantManagement_Applicatin.Repository;

using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.OrderItems
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRestaurantManagementRepository<OrderItem> _orderItemRepository;
        public OrderItemService(IRestaurantManagementRepository<OrderItem> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task AddOrderItemService(OrderItem orderItem)
        {
           await _orderItemRepository.AddItemRepo(orderItem);
        }

        public async Task DeleteOrderItemService(OrderItem orderItem)
        {
            await _orderItemRepository.DeleteItemRepo(orderItem);
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsService()
        {
            return await _orderItemRepository
                .GetAllItemsRepo();  
        }

        public async Task<OrderItem> GetOrderItemByIdService(int id)
        {
            return await _orderItemRepository.GetItemByIdRepo(id);
        }

        public async Task UpdateOrderItemService(OrderItem orderItem)
        {
           await _orderItemRepository.UpdateItemRepo(orderItem);
        }
    }
}

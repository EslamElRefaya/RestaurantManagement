using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.OrderItems
{
   public interface IOrderItemService
    {
       Task<IEnumerable<OrderItem>> GetAllOrderItemsService();
        Task<OrderItem> GetOrderItemByIdService(int id);
        Task AddOrderItemService(OrderItem orderItem);
        Task UpdateOrderItemService(OrderItem orderItem);
        Task DeleteOrderItemService(OrderItem orderItem);
    }
}

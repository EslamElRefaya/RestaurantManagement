using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.Orders
{
   public interface IOrderServices
    {
        Task<IEnumerable<Order>> GetAllOrdersService();
        Task<Order> GetOrderByIdService(int id);
        Task AddOrderService(Order order);
        Task DeleteOrderService(Order order);
        Task UpdateOrderService(Order order);
    }
}

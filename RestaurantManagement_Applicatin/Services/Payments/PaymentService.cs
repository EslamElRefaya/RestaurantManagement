
using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IRestaurantManagementRepository<Order> _orderRepository;

        public PaymentService(IRestaurantManagementRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task PayService(int orderId)
        {
          var order=await _orderRepository.GetItemByIdRepo(orderId);
            if (order == null)
                throw new ArgumentException("Order not found");
            order.PaymentState = PaymentStatus.Paid;
            order.Status = OrderStatus.Completed;
            await _orderRepository.UpdateItemRepo(order);

        }
    }
}

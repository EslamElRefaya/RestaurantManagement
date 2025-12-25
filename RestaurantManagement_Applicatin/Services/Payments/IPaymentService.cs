namespace RestaurantManagement_Applicatin.Services.Payments
{
   public interface IPaymentService
    {
        Task PayService(int orderId);
    }
}

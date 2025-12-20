namespace RestaurantManagement_Domain.Models
{
    public enum OrderStatus
    {
        Pending = 0,
        Completed = 1,
        Canceled = 2
    }

    public class Order
    {

        public int OrderId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime? CreatedAt { get; set; }=DateTime.UtcNow;

        public int RestaurantId { get; set; }   // FK ✅
        public Restaurant Restaurant { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }



    }
}

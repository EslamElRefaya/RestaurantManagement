using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement_Domain.Models
{
    public enum OrderStatus
    {
        Pending = 0,
        Completed = 1,
        Canceled = 2
    }
    public enum PaymentStatus
    {
        Unpaid = 0,
        Paid = 1
    }
    public class Order
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime? CreatedAt { get; set; }=DateTime.UtcNow;

        public int RestaurantId { get; set; }   
        public Restaurant Restaurant { get; set; }

        public decimal TotalPrice { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }=string.Empty;
        
        public PaymentStatus PaymentState { get; set; } = PaymentStatus.Unpaid;
        public bool IsPayment => PaymentState == PaymentStatus.Paid;

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}

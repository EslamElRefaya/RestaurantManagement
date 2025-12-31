using System.ComponentModel.DataAnnotations;
using RestaurantManagement_Shared.Dtos.OrderItems;

namespace RestaurantManagement_Shared.Dtos.Orders
{
    public class DetailsOrderDto
    {
        public int OrderId { get; set; }
        public string RestaurantName { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string UserFullName { get; set; }=default!;
        public IEnumerable<DetailsOrderItemDto>? Items { get; set; }
        public string? Notes { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = default!;
        public string PaymentState { get; set; } = default!;

    }
}

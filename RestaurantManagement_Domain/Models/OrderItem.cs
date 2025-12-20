namespace RestaurantManagement_Domain.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; } = default!;
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;

    }
}

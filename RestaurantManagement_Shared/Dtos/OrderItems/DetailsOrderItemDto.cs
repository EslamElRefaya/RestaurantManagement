namespace RestaurantManagement_Shared.Dtos.OrderItems
{
   public class DetailsOrderItemDto
    {
        public int OrderItemId { get; set; }
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int OrderId { get; set; }
        public decimal TotalPrice => PricePerUnit * Quantity;


    }
}

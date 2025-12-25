using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement_Shared.Dtos.OrderItems
{
   public class AddAndEditOrderItemDto
    {
        [Range(1,100)] 
        public int Quantity { get; set; }
        public int FoodId { get; set; }
        public int OrderId { get; set; }
    }
}

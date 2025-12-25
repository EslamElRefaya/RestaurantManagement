using System.ComponentModel.DataAnnotations;
namespace RestaurantManagement_Shared.Dtos.Orders
{
   public class AddOrderDto
    {
        public int RestaurantId { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace RestaurantManagement_Shared.Dtos.Orders
{
   public class AddOrderDto
    {
        public int RestaurantId { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }
        [MaxLength(450)]
        public string UserId { get; set; }=string.Empty;
    }
}

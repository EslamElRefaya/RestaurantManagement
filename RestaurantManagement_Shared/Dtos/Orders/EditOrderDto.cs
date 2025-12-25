using System.ComponentModel.DataAnnotations;
using RestaurantManagement_Domain.Models;
namespace RestaurantManagement_Shared.Dtos.Orders
{
   public class EditOrderDto
    {
        [MaxLength(500)]
        public string? Notes { get; set; }

        public OrderStatus Status { get; set; }
    }
}

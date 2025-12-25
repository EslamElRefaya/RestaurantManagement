using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace RestaurantManagement_Shared.Dtos.Foods
{
    public class AddAndEditFoodDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public IFormFile? Image { get; set; } 
        public int MenuId { get; set; }
    }
}

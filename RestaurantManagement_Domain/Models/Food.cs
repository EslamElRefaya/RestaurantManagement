using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement_Domain.Models
{
    public class Food:BaseEntity
    {
        public decimal  Price { get; set; }
        [MaxLength(300)]
        public string URL { get; set; } = string.Empty;

        public int MenuId { get; set; }
        public Menu Menu { get; set; } = default!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<FoodReview> FoodReviews { get; set; } = new List<FoodReview>();
    }
}

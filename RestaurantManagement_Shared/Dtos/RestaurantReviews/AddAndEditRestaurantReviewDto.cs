using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Shared.Dtos.RestaurantReviews
{
   public class AddAndEditRestaurantReviewDto
    {
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int RestaurantId { get; set; }
    }
}

namespace RestaurantManagement_Shared.Dtos.FoodReviews
{
   public class AddAndEditFoodReviewDto
    {
        public string Description { get; set; } = string.Empty;
        public int FoodId { get; set; }
    }
}

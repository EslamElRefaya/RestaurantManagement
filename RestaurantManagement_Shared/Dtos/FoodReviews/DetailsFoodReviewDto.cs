namespace RestaurantManagement_Shared.Dtos.FoodReviews
{
    public class DetailsFoodReviewDto
    {
        public int FoodReviewId { get; set; }
        public string Description { get; set; } = string.Empty;

        public int FoodId { get; set; }
        public string FoodName { get; set; }
    }
}

namespace RestaurantManagement_Shared.Dtos.RestaurantReviews
{
  public class DetailsRestaurantReviewDto
    {

        public int RestaurantReviewId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int RestaurantId { get; set; }
        public string  RestaurantName { get; set; } = default!;
    }
}

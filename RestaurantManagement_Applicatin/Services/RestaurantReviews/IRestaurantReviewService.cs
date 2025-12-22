using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.RestaurantReviews
{
   public interface IRestaurantReviewService
    {
        Task<IEnumerable<RestaurantReview>> GetAllRestaurantReviewsService();
        Task<RestaurantReview?> GetRestaurantReviewByIdService(int id);
        Task AddRestaurantReviewService(RestaurantReview restaurantReview);
        Task UpdateRestaurantReviewService(RestaurantReview restaurantReview);
        Task DeleteRestaurantReviewService(RestaurantReview restaurantReview);
    }
}

using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.FoodReviews
{
    public interface IFoodReviewServices
    {
        Task<IEnumerable<FoodReview>> GetAllFoodReviewsService();
        Task<FoodReview> GetFoodReviewByIdService(int id);
        Task AddFoodReviewService(FoodReview foodReview);
        Task UpdateFoodReviewService(FoodReview foodReview);
        Task DeleteFoodReviewService(FoodReview foodReview);
    }
}

using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.FoodReviews
{
    public class FoodReviewServices : IFoodReviewServices
    {
        private readonly IRestaurantManagementRepository<FoodReview> _foodReviewRepository;

        public FoodReviewServices(IRestaurantManagementRepository<FoodReview> foodReviewRepository)
        {
            _foodReviewRepository = foodReviewRepository;
        }

        public async Task AddFoodReviewService(FoodReview foodReview)
        {
            await _foodReviewRepository.AddItemRepo(foodReview);
        }

        public async Task DeleteFoodReviewService(FoodReview foodReview)
        {
            await _foodReviewRepository.DeleteItemRepo(foodReview);
        }

        public async Task<IEnumerable<FoodReview>> GetAllFoodReviewsService()
        {
            return await _foodReviewRepository.GetAllItemsRepo();
        }

        public async Task<FoodReview> GetFoodReviewByIdService(int id)
        {
            return await _foodReviewRepository.GetItemByIdRepo(id); 
        }

        public async Task UpdateFoodReviewService(FoodReview foodReview)
        {
            await _foodReviewRepository.UpdateItemRepo(foodReview);
        }
    }
}

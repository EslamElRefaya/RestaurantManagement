using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.RestaurantReviews
{
    public class RestaurantReviewService : IRestaurantReviewService
    {
        private readonly IRestaurantManagementRepository<RestaurantReview> _restaurantReviewRepository;

        public RestaurantReviewService(IRestaurantManagementRepository<RestaurantReview> restaurantReviewRepository)
        {
            _restaurantReviewRepository = restaurantReviewRepository;
        }

        public async Task AddRestaurantReviewService(RestaurantReview restaurantReview)
        {
            await _restaurantReviewRepository.AddItemRepo(restaurantReview);
        }

        public async Task DeleteRestaurantReviewService(RestaurantReview restaurantReview)
        {
            await _restaurantReviewRepository.DeleteItemRepo(restaurantReview);
        }

        public async Task<IEnumerable<RestaurantReview>> GetAllRestaurantReviewsService()
        {
            return await _restaurantReviewRepository.GetAllItemsRepo();
        }

        public async Task<RestaurantReview?> GetRestaurantReviewByIdService(int id)
        {
            return await _restaurantReviewRepository.GetItemByIdRepo(id);
        }

        public async Task UpdateRestaurantReviewService(RestaurantReview restaurantReview)
        {
            await _restaurantReviewRepository.UpdateItemRepo(restaurantReview);
        }
    }
}

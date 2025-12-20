using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.Restaurants
{
    public class RestaurantsService : IRestaurantsService
    {
        private readonly IRestaurantManagementRepository<Restaurant> _restaurantRepository;

        public RestaurantsService(IRestaurantManagementRepository<Restaurant> restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsService()
        {
            return await _restaurantRepository.GetAllItemsRepo();
        }

        public async Task<Restaurant> GetRestaurantByIdService(int id)
        {
            return await _restaurantRepository.GetItemByIdRepo(id);
        }

        public async Task AddRestaurantService(Restaurant restaurant)
        {
            await _restaurantRepository.AddItemRepo(restaurant);
        }

        public async Task DeleteRestaurantService(Restaurant restaurant)
        {
            await _restaurantRepository.DeletetemRepo(restaurant);
        }

        public async Task UpdateRestaurantService(Restaurant restaurant)
        {
            await _restaurantRepository.UpdateItemRepo(restaurant);
        }
    }
}

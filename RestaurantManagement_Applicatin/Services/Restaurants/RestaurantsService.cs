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
            restaurant.IsOpenning = CalculateIsOpenning(restaurant.StartingWork,restaurant.WorkingHours );

            await _restaurantRepository.AddItemRepo(restaurant);
        }

        public async Task UpdateRestaurantService(Restaurant restaurant)
        {
            restaurant.IsOpenning = CalculateIsOpenning(restaurant.StartingWork, restaurant.WorkingHours);
            await _restaurantRepository.UpdateItemRepo(restaurant);
        }

        public async Task DeleteRestaurantService(Restaurant restaurant)
        {
            await _restaurantRepository.DeleteItemRepo(restaurant);
        }

        private bool CalculateIsOpenning(DateTime startingWork, int workingHours)
        {
            // case 1: Restaurant is open 24 hours
            if (workingHours >= 24)
                return true;

            // current time (time only)
            TimeSpan timeNow = DateTime.Now.TimeOfDay;

            // starting time (time only)
            TimeSpan startTime = startingWork.TimeOfDay;

            // calculate closing time
            TimeSpan closingTime = startTime.Add(TimeSpan.FromHours(workingHours));

            // case 2: Restaurant closes after midnight
            // ex: opens at 19:00 and closes at 01:00
            if (closingTime < startTime)
            {
                return timeNow >= startTime || timeNow <= closingTime;
            }

            // case 3: Normal Restaurant (same day)
            // ex: opens at 09:00 and closes at 17:00
            return timeNow >= startTime && timeNow <= closingTime;
        }
    }
}

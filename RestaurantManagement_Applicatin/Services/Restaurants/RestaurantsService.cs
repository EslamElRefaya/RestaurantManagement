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
            await _restaurantRepository.DeletetemRepo(restaurant);
        }

        private bool CalculateIsOpenning(TimeSpan startingWork, int workingHours)
        {
            //case 1: Restaurant is open 24 hours
            if (workingHours >= 24)
                return true;

            // calculate current time hour and minutes only
            TimeSpan timeNow = DateTime.Now.TimeOfDay;

            //calculate closing time
            TimeSpan closingTime = startingWork.Add(TimeSpan.FromHours(workingHours));

            //case:2 Restaurant closes after midnight
            //ex : opens at 19:00 and closes at 01:00
            if (closingTime < startingWork)
            {
             
                return timeNow >= startingWork || timeNow <= closingTime;
            }

            //case 3: Normal Restaurant (opens and closes on the same day)
            // ex: opens at 09:00 and closes at 17:00
            return timeNow >= startingWork && timeNow <= closingTime;
        }

    }
}

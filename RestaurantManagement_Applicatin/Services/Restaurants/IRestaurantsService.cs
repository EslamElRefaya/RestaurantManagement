using RestaurantManagement_Domain.Models;
namespace RestaurantManagement_Applicatin.Services.Restaurants
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurantsService();
        Task<Restaurant> GetRestaurantByIdService(int id);
        Task AddRestaurantService(Restaurant restaurant);
        Task UpdateRestaurantService(Restaurant restaurant);
        Task DeleteRestaurantService(Restaurant restaurant);
      
    }
}

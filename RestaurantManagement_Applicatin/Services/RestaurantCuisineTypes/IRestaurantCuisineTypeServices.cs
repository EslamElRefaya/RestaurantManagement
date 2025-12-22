using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.RestaurantCuisineTypes
{
  public interface IRestaurantCuisineTypeServices
    {
        Task<IEnumerable<RestaurantCuisineType>> GetAllRestaurantCuisineTypesService();
        Task<RestaurantCuisineType> GetRestaurantCuisineTypeByIdService(int id);
        Task AddRestaurantCuisineTypeService(RestaurantCuisineType restaurantCuisineType);
        Task UpdateRestaurantCuisineTypeService(RestaurantCuisineType restaurantCuisineType);
        Task DeleteRestaurantCuisineTypeService(RestaurantCuisineType restaurantCuisineType);

    }
}

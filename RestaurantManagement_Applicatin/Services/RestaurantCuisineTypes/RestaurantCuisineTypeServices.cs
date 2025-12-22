using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.RestaurantCuisineTypes
{
    public class RestaurantCuisineTypeServices : IRestaurantCuisineTypeServices
    {
        private readonly IRestaurantManagementRepository<RestaurantCuisineType> _restaurantCuisineTypeRepository;

        public RestaurantCuisineTypeServices(IRestaurantManagementRepository<RestaurantCuisineType> restaurantCuisineTypeRepository)
        {
            _restaurantCuisineTypeRepository = restaurantCuisineTypeRepository;
        }

        public async Task AddRestaurantCuisineTypeService(RestaurantCuisineType restaurantCuisineType)
        {
            await _restaurantCuisineTypeRepository.AddItemRepo(restaurantCuisineType);
        }

        public async Task DeleteRestaurantCuisineTypeService(RestaurantCuisineType restaurantCuisineType)
        {
            await _restaurantCuisineTypeRepository.DeleteItemRepo(restaurantCuisineType);
        }

        public async Task<IEnumerable<RestaurantCuisineType>> GetAllRestaurantCuisineTypesService()
        {
          return  await _restaurantCuisineTypeRepository.GetAllItemsRepo();
        }

        public async Task<RestaurantCuisineType> GetRestaurantCuisineTypeByIdService(int id)
        {
            return await _restaurantCuisineTypeRepository.GetItemByIdRepo(id);
        }

        public async Task UpdateRestaurantCuisineTypeService(RestaurantCuisineType restaurantCuisineType)
        {
            await _restaurantCuisineTypeRepository.UpdateItemRepo(restaurantCuisineType);
        }
    }
}

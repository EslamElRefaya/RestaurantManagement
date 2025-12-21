using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.CuisineTypes
{
   public class CuisineTypeServices : ICuisineTypeServices
    {
        private readonly IRestaurantManagementRepository<CuisineType> _cuisineTypeRepository;
        public CuisineTypeServices(IRestaurantManagementRepository<CuisineType> cuisineTypeRepository)
        {
            _cuisineTypeRepository = cuisineTypeRepository;
        }

        public async Task AddCuisineTypeService(CuisineType cuisineType)
        {
            await _cuisineTypeRepository.AddItemRepo(cuisineType);
        }

        public async Task DeleteCuisineTypeService(CuisineType cuisineType)
        {
            await _cuisineTypeRepository.DeleteItemRepo(cuisineType);
        }

        public async Task<IEnumerable<CuisineType>> GetAllCuisineTypesService()
        {
            return await _cuisineTypeRepository.GetAllItemsRepo();
        }

        public async Task<CuisineType> GetCuisineTypeByIdService(int id)
        {
            return await _cuisineTypeRepository.GetItemByIdRepo(id);
        }

        public async Task UpdateCuisineTypeService(CuisineType cuisineType)
        {
            await _cuisineTypeRepository.UpdateItemRepo(cuisineType);
        }
    }
}

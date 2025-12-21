using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.CuisineTypes
{
   public interface ICuisineTypeServices
    {
        Task<IEnumerable<CuisineType>> GetAllCuisineTypesService();
        Task<CuisineType> GetCuisineTypeByIdService(int id);
        Task AddCuisineTypeService(CuisineType cuisineType);
        Task UpdateCuisineTypeService(CuisineType cuisineType);
        Task DeleteCuisineTypeService(CuisineType cuisineType);
    }
}

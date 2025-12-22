using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.Foods
{
   public interface IFoodServices
    {
        Task<IEnumerable<Food>> GetAllFoodsService();
        Task<Food> GetFoodByIdService(int id);
        Task AddFoodService(Food food);
        Task UpdateFoodService(Food food);
        Task DeleteFoodService(Food food);
    }
}

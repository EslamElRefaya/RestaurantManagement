using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.MealTypes
{
   public interface IMealTypeServices
    {
       Task<IEnumerable<MealType>> GetAllMealTypesService();
        Task<MealType> GetMealTypeByIdService(int id);
        Task AddMealTypeService(MealType mealType);
        Task UpdateMealTypeService(MealType mealType);
        Task DeleteMealTypeService(MealType mealType);
    }
}

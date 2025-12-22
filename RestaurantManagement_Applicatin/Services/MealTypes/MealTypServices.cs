using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.MealTypes
{
    public class MealTypServices : IMealTypeServices
    {
        private readonly IRestaurantManagementRepository<MealType> _mealTypeRepository;

        public MealTypServices(IRestaurantManagementRepository<MealType> mealTypeRepository)
        {
            _mealTypeRepository = mealTypeRepository;
        }

        public async Task AddMealTypeService(MealType mealType)
        {
            await _mealTypeRepository.AddItemRepo(mealType);
        }

        public async Task DeleteMealTypeService(MealType mealType)
        {
            await _mealTypeRepository.DeleteItemRepo(mealType);
        }

        public async Task<IEnumerable<MealType>> GetAllMealTypesService()
        {
            return await _mealTypeRepository.GetAllItemsRepo();
        }

        public async Task<MealType> GetMealTypeByIdService(int id)
        {
            return await _mealTypeRepository.GetItemByIdRepo(id);
        }

        public async Task UpdateMealTypeService(MealType mealType)
        {
            await _mealTypeRepository.UpdateItemRepo(mealType);
        }
    }
}

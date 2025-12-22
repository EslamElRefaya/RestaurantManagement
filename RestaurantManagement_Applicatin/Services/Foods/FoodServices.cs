using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Services.Foods
{
    public class FoodServices : IFoodServices
    {
        private readonly IRestaurantManagementRepository<Food> _foodRepository;

        public FoodServices(IRestaurantManagementRepository<Food> foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task AddFoodService(Food food)
        {
            await _foodRepository.AddItemRepo(food);
        }

        public async Task DeleteFoodService(Food food)
        {
            await _foodRepository.DeleteItemRepo(food);
        }

        public async Task<IEnumerable<Food>> GetAllFoodsService()
        {
            return await _foodRepository.GetAllItemsRepo();
        }

        public async Task<Food> GetFoodByIdService(int id)
        {
            return await _foodRepository.GetItemByIdRepo(id);
        }

        public async Task UpdateFoodService(Food food)
        {
            await _foodRepository.UpdateItemRepo(food);
        }
    }
}

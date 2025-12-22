using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Data;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Repository
{
    public class FoodRepoistory : IRestaurantManagementRepository<Food>
    {
        private readonly ApplicationDbContext _context;

        public FoodRepoistory(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemRepo(Food food)
        {
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemRepo(Food food)
        {
            _context.Remove(food);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Food>> GetAllItemsRepo()
        {
            return await _context.Foods
                .Include(f => f.Menu)
                .ToListAsync();
        }

        public async Task<Food> GetItemByIdRepo(int id)
        {
            return await _context.Foods
               .Include(f => f.Menu)
               .SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task UpdateItemRepo(Food food)
        {
            _context.Update(food);
            await _context.SaveChangesAsync();
        }
    }
}

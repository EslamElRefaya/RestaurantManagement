using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Data;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Repository
{
    public class MealTypeRepository : IRestaurantManagementRepository<MealType>
    {
        private readonly ApplicationDbContext _context;
        public MealTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemRepo(MealType mealType)
        {
            await _context.MealTypes.AddAsync(mealType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemRepo(MealType mealType)
        {
            _context.MealTypes.Remove(mealType);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MealType>> GetAllItemsRepo()
        {
            return await _context.MealTypes.ToListAsync();
        }

        public async Task<MealType> GetItemByIdRepo(int id)
        {
            return await _context.MealTypes.SingleOrDefaultAsync(m=>m.Id==id);
        }

        public async Task UpdateItemRepo(MealType mealType)
        {
            _context.MealTypes.Update(mealType);
            await _context.SaveChangesAsync();
        }
    }
}

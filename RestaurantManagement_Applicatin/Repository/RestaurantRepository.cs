using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Data;
using RestaurantManagement_Domain.Models;
namespace RestaurantManagement_Applicatin.Repository
{
    public class RestaurantRepository : IRestaurantManagementRepository<Restaurant>
    {
        private readonly ApplicationDbContext _context;

        public RestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurant>> GetAllItemsRepo()
        {
           return await _context.Restaurants
                
                .ToListAsync();
        }

        public async Task<Restaurant> GetItemByIdRepo(int id)
        {
            return await _context.Restaurants.SingleOrDefaultAsync(r=>r.Id==id);
            
        }

        public async Task AddItemRepo(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemRepo(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeletetemRepo(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }
       
    }
}

using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Data;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Repository
{
    public class OrderRepository : IRestaurantManagementRepository<Order>
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemRepo(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemRepo(Order order)
        {
            _context.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllItemsRepo()
        {
            return await _context.Orders
                .Include(o=>o.Restaurant)
                .Include(o=>o.ApplicationUser)
                .Include(o => o.OrderItems).ThenInclude(i=>i.Food)
                .ToListAsync();
        }

        public async Task<Order?> GetItemByIdRepo(int id)
        {
            return await _context.Orders
                .Include(o=>o.Restaurant)
                .Include(o => o.OrderItems).ThenInclude(i => i.Food)
                .SingleOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task UpdateItemRepo(Order order)
        {
            _context.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}

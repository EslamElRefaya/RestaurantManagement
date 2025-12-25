using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Data;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Repository
{
    public class OrderItemRepository : IRestaurantManagementRepository<OrderItem>
    {
        private readonly ApplicationDbContext _context;
        public OrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemRepo(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemRepo(OrderItem orderItem)
        {
            _context.Remove(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetAllItemsRepo()
        {
            return await _context.OrderItems
                .Include(oi => oi.Food)
                .Include(oi => oi.Order)
                .ToListAsync();
        }

        public async Task<OrderItem?> GetItemByIdRepo(int id)
        {
            return await _context.OrderItems
                .Include(oi => oi.Food)
                .Include(oi => oi.Order)
                .SingleOrDefaultAsync(oi => oi.OrderItemId == id);
        }

        public async Task UpdateItemRepo(OrderItem orderItem)
        {
            _context.Update(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Data;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Repository
{
    public class RestaurantReviewRepository : IRestaurantManagementRepository<RestaurantReview>
    {
        private readonly ApplicationDbContext _context;
        public RestaurantReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RestaurantReview>> GetAllItemsRepo()
        {
            return await _context.RestaurantReviews
                 .Include(rv=>rv.Restaurant)
                .ToListAsync();
        }

        public async Task<RestaurantReview> GetItemByIdRepo(int id)
        {
            return await _context.RestaurantReviews
                .Include(rv => rv.Restaurant)
                .SingleOrDefaultAsync(r => r.RestaurantReviewId == id);
        }

        public async Task AddItemRepo(RestaurantReview restaurantReview)
        {
            await _context.RestaurantReviews.AddAsync(restaurantReview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemRepo(RestaurantReview restaurantReview)
        {
            _context.RestaurantReviews.Remove(restaurantReview);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateItemRepo(RestaurantReview restaurantReview)
        {
            _context.RestaurantReviews.Update(restaurantReview);
            await _context.SaveChangesAsync();
        }
    }
}

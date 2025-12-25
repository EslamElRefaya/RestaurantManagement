using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Data;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Repository
{
    public class FoodReviewRepository : IRestaurantManagementRepository<FoodReview>
    {
        private readonly ApplicationDbContext _context;

        public FoodReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemRepo(FoodReview foodReview)
        {
            await _context.FoodReviews.AddAsync(foodReview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemRepo(FoodReview foodReview)
        {
            _context.FoodReviews.Remove(foodReview);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FoodReview>> GetAllItemsRepo()
        {
            return await _context.FoodReviews
                 .Include(fr => fr.Food)
                .ToListAsync();
        }

        public async Task<FoodReview?> GetItemByIdRepo(int id)
        {
            return await _context.FoodReviews
                .Include(fr => fr.Food)
                .SingleOrDefaultAsync(fr=>fr.FoodReviewId==id);
        }

        public async Task UpdateItemRepo(FoodReview foodReview)
        {
            _context.FoodReviews.Update(foodReview);
            await _context.SaveChangesAsync();
        }
    }
}

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
    public class CuisineTypRepository : IRestaurantManagementRepository<CuisineType>
    {
        private readonly ApplicationDbContext _context;

        public CuisineTypRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CuisineType>> GetAllItemsRepo()
        {
            return await _context.cuisineTypes.ToListAsync();
        }

        public async Task<CuisineType> GetItemByIdRepo(int id)
        {
            return await _context.cuisineTypes.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task AddItemRepo(CuisineType cuisineType)
        {
            await _context.cuisineTypes.AddAsync(cuisineType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemRepo(CuisineType cuisineType)
        {
            _context.cuisineTypes.Remove(cuisineType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemRepo(CuisineType cuisineType)
        {
            _context.cuisineTypes.Update(cuisineType);
            await _context.SaveChangesAsync();
        }
    }
}

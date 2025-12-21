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
    public class CuisineTypeRepository : IRestaurantManagementRepository<CuisineType>
    {
        private readonly ApplicationDbContext _context;

        public CuisineTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemRepo(CuisineType cuisineType)
        {
            await _context.cuisineTypes.AddAsync(cuisineType);
            await _context.SaveChangesAsync();
        }

        public async Task DeletetemRepo(CuisineType cuisineType)
        {
            _context.Remove(cuisineType);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CuisineType>> GetAllItemsRepo()
        {
            return await _context.cuisineTypes.ToListAsync();
        }

        public async Task<CuisineType> GetItemByIdRepo(int id)
        {
            return await _context.cuisineTypes.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateItemRepo(CuisineType cuisineType)
        {
            _context.Update(cuisineType);
            await _context.SaveChangesAsync();
        }
    }
}

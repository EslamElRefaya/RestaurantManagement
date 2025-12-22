using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Applicatin.Services.RestaurantCuisineTypes;
using RestaurantManagement_Data;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Repository
{
    public class RestaurantCuisineTypeRepository : IRestaurantManagementRepository<RestaurantCuisineType>
    {
        private readonly ApplicationDbContext _context;

        public RestaurantCuisineTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemRepo(RestaurantCuisineType restaurantCuisineType)
        {
            await _context.RestaurantCuisineType.AddAsync(restaurantCuisineType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemRepo(RestaurantCuisineType restaurantCuisineType)
        {
             _context.Remove(restaurantCuisineType);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RestaurantCuisineType>> GetAllItemsRepo()
        {
            return await _context.RestaurantCuisineType
                .Include(r=>r.Restaurant)
                .Include(r=>r.CuisineType)
                .ToListAsync();
        }

        public async Task<RestaurantCuisineType> GetItemByIdRepo(int id)
        {
            return await _context.RestaurantCuisineType
                .Include(r => r.Restaurant)
                .Include(r => r.CuisineType)
                .SingleOrDefaultAsync(rc=>rc.RestaurantCuisineTypeId==id);
        }

        public async Task UpdateItemRepo(RestaurantCuisineType restaurantCuisineType)
        {
            _context.Update(restaurantCuisineType);
            await _context.SaveChangesAsync();
        }
    }
}

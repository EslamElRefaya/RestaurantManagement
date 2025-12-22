using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantManagement_Domain.Models;
namespace RestaurantManagement_Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context)
                          : base(context)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> RestaurantReviews { get; set; }
        public DbSet<RestaurantCuisineType> RestaurantCuisineType { get; set; }
        public DbSet<CuisineType> cuisineTypes { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodReview> FoodReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantCuisineType>()
                .HasOne(rc => rc.Restaurant)
                .WithMany(r => r.RestaurantCuisineType)
                .HasForeignKey(rc => rc.RestaurantId);

            modelBuilder.Entity<RestaurantCuisineType>()
                .HasOne(rc => rc.CuisineType)
                .WithMany(c => c.RestaurantCuisineType)
                .HasForeignKey(rc => rc.CuisineTypeId);
        }


    }
}

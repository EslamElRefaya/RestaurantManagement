using Microsoft.EntityFrameworkCore;

namespace RestaurantManagement_Data
{
   public class ApplicationDbContext: DbContext   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context)
                          :base(context) 
        {
        }
       
    }
}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RestaurantManagement_Domain.Models
{
    public class ApplicationUser: IdentityUser
    {
        [MaxLength(100)]
        public string FristName{ get; set; }=string.Empty;
        [MaxLength(100)]
        public string LastName{ get; set; }=string.Empty;

        public ICollection<Order> Orders{ get; set; } = new List<Order>();
    }
}

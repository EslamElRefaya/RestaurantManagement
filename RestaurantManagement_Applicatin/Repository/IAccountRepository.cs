using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser?> FindByUserNameAsync(string userName);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IList<string>> GetUserRolesAsync(ApplicationUser user);

        // ===== New method to assign role to user =====
        Task AddUserRoleAsync(ApplicationUser user, string role);

        // ===== New method to update role =====
        Task<IdentityResult> UpdateUserRoleAsync(ApplicationUser user, string newRole);

    }
}

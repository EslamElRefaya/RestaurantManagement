using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RestaurantManagement_Domain.Models;

namespace RestaurantManagement_Applicatin.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
            => await _userManager.CreateAsync(user, password);

        public async Task<ApplicationUser?> FindByUserNameAsync(string userName)
            => await _userManager.FindByNameAsync(userName);

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
            => await _userManager.CheckPasswordAsync(user, password);

        public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
            => await _userManager.GetRolesAsync(user);

        public async Task AddUserRoleAsync(ApplicationUser user, string role)
        {
            // Add user to role
            await _userManager.AddToRoleAsync(user, role);
        }
        public async Task<IdentityResult> UpdateUserRoleAsync(ApplicationUser user, string newRole)
        {
            // Remove existing roles
            var roles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!removeResult.Succeeded) return removeResult;

            // Add new role
            return await _userManager.AddToRoleAsync(user, newRole);
        }


    }
}

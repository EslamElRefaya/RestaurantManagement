
using RestaurantManagement_Applicatin.Dtos.ApplicationUsers;

namespace RestaurantManagement_Applicatin.Services.Account
{
    public interface IAccountService
    {
        Task<(bool IsSuccess, IEnumerable<string> Errors)> RegisterAsync(AddNewUserDto dto);
        Task<object?> LoginAsync(LoginDto dto);
        // ===== New method =====
        Task<(bool IsSuccess, IEnumerable<string> Errors)> UpdateRoleAsync(UpdateRoleDto dto);

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement_Applicatin.Dtos.ApplicationUsers;
using RestaurantManagement_Applicatin.Services.Account;

namespace RestaurantManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUsersAsync(AddNewUserDto addNewUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.RegisterAsync(addNewUserDto);

            if (result.IsSuccess)
                return Ok("Succeeded!");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _accountService.LoginAsync(loginDto);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [Authorize(Roles = "Admin")]
        // ===== Update Role of a User =====
        [HttpPost("UpdateRoleUser")]
        public async Task<IActionResult> UpdateRoleUser(UpdateRoleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.UpdateRoleAsync(dto);

            if (result.IsSuccess)
                return Ok("Role updated successfully!");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error);

            return BadRequest(ModelState);
        }


    }
}

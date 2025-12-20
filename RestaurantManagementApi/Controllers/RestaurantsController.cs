using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement_Applicatin.Services.Restaurants;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.Restaurants;

namespace RestaurantManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantsService _restaurantsService;

        public RestaurantsController(IRestaurantsService restaurantsService)
        {
            _restaurantsService = restaurantsService;
        }
        [HttpGet("Get All Restaurants")]
        public async Task<IActionResult> GetAllRestaurantsAsync()
        {
            var restaurants = await _restaurantsService.GetAllRestaurantsService();
            return Ok(restaurants);
        }
        [HttpGet("Get Restaurant By Id/{id}")]
        public async Task<IActionResult> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _restaurantsService.GetRestaurantByIdService(id);
            return Ok(restaurant);
        }
        [HttpPost("Add Restaurant")]
        public async Task<IActionResult> AddRestaurantAsync(RestaurantDto restaurantDto)
        {
            if (restaurantDto == null)
                return BadRequest("Restaurant must be Required !!");
            var restaurant = new Restaurant()
            {
                Name = restaurantDto.Name,
                Address = restaurantDto.Address,
                CreatedAt = restaurantDto.CreatedAt,
                WorkingHours = restaurantDto.WorkingHours,
                IsOpenning = restaurantDto.IsOpenning,
            };

            await _restaurantsService.AddRestaurantService(restaurant);
            return Ok(restaurant);
        }
        [HttpPut("Update Restaurant/{id}")]
        public async Task<IActionResult> UpdateRestaurantAsync(int id, RestaurantDto restaurantDto)
        {
            var restaurant = await _restaurantsService.GetRestaurantByIdService(id);
            if (restaurant == null)
                return NotFound("Restaurant Not Found !!");
            restaurant.Name = restaurantDto.Name;
            restaurant.Address = restaurantDto.Address;
            restaurant.CreatedAt = restaurantDto.CreatedAt;
            restaurant.WorkingHours = restaurantDto.WorkingHours;
            restaurant.IsOpenning = restaurantDto.IsOpenning;
            await _restaurantsService.UpdateRestaurantService(restaurant);
            return Ok(restaurant);
        }
        [HttpDelete("Delete Restaurant/{id}")]
        public async Task<IActionResult> DeleteRestaurantAsync(int id)
        {
            var restaurant = await _restaurantsService.GetRestaurantByIdService(id);
            if (restaurant == null)
                return NotFound("Restaurant Not Found !!");
            await _restaurantsService.DeleteRestaurantService(restaurant);
            return Ok(restaurant);
        }
    }
}

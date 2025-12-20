using AutoMapper;
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
        private readonly IMapper _mapper;

        public RestaurantsController(IRestaurantsService restaurantsService, IMapper mapper)
        {
            _restaurantsService = restaurantsService;
            _mapper = mapper;
        }
        [HttpGet("Get All Restaurants")]
        public async Task<IActionResult> GetAllRestaurantsAsync()
        {
            var restaurants = await _restaurantsService.GetAllRestaurantsService();
            return Ok(restaurants);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _restaurantsService.GetRestaurantByIdService(id);
            if (restaurant == null)
                return NotFound($"No founded this Restaurant with this id:{id}");
            return Ok(restaurant);
        }
        [HttpPost("Add Restaurant")]
        public async Task<IActionResult> AddRestaurantAsync(AddAndUpdateRestaurantDto restaurantDto)
        {
            if (restaurantDto == null)
                return BadRequest("Restaurant must be Required !!");
            var restaurant = new Restaurant()
            {
                Name=restaurantDto.Name,
                Address = restaurantDto.Address,
                CreatedAt = restaurantDto.CreatedAt,
                WorkingHours = restaurantDto.WorkingHours,
                StartingWork = restaurantDto.StartingWork,
            };

            await _restaurantsService.AddRestaurantService(restaurant);
            return Ok(restaurant);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurantAsync(int id, AddAndUpdateRestaurantDto restaurantDto)
        {
            var restaurant = await _restaurantsService.GetRestaurantByIdService(id);

            if (restaurant == null)
                return NotFound("Restaurant Not Found !!");

            if(!ModelState.IsValid)
                return BadRequest("Restaurant Data must be provided !!");
            else
            {
                restaurant.Name = restaurantDto.Name;
                restaurant.Address = restaurantDto.Address;
                restaurant.CreatedAt = restaurantDto.CreatedAt;
                restaurant.WorkingHours = restaurantDto.WorkingHours;
                restaurant.StartingWork = restaurantDto.StartingWork;

                await _restaurantsService.UpdateRestaurantService(restaurant);
                return Ok(restaurant);
            }
               
        }
        [HttpDelete("{id}")]
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

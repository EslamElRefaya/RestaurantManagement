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

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurantsAsync()
        {
            var restaurants = await _restaurantsService.GetAllRestaurantsService();
            if(restaurants == null || !restaurants.Any())
                return NotFound("No Restaurants Add yet!!");

            var data=_mapper.Map<IEnumerable<DetailsRestaurantDto>>(restaurants);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _restaurantsService.GetRestaurantByIdService(id);
            if(restaurant == null)
                return NotFound("Restaurant Not Found !!");
            var data = _mapper.Map<DetailsRestaurantDto>(restaurant);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurantAsync(AddAndUpdateRestaurantDto restaurantDto)
        {
            if (restaurantDto == null)
                return BadRequest("Restaurant must be Required !!");
            /*
             var restaurant = new Restaurant()
             {
                 Name = restaurantDto.Name,
                 Address = restaurantDto.Address,
                 CreatedAt = restaurantDto.CreatedAt,
                 StartingWork = restaurantDto.StartingWork,
                 WorkingHours = restaurantDto.WorkingHours,
             };
            */
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            await _restaurantsService.AddRestaurantService(restaurant);
            return Ok(restaurant);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurantAsync(int id, AddAndUpdateRestaurantDto restaurantDto)
        {
            var restaurant = await _restaurantsService.GetRestaurantByIdService(id);
            if (restaurant == null)
                return NotFound("Restaurant Not Found !!");
           _mapper.Map(restaurantDto, restaurant);

            await _restaurantsService.UpdateRestaurantService(restaurant);
            return Ok(restaurant);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantAsync(int id)
        {
            var restaurant = await _restaurantsService.GetRestaurantByIdService(id);
            if (restaurant == null)
                return NotFound("Restaurant Not Found !!");
            await _restaurantsService.DeleteRestaurantService(restaurant);
            return Ok("Delete Operation is Successfully..");
        }
    }
}

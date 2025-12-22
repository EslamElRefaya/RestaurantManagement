using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement_Applicatin.Services.RestaurantCuisineTypes;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.RestaurantCuisineType;

namespace RestaurantManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantCuisineTypesController : ControllerBase
    {
        private readonly IRestaurantCuisineTypeServices _restaurantCuisineTypeServices;
        private readonly IMapper _mapper;
        public RestaurantCuisineTypesController(IRestaurantCuisineTypeServices restaurantCuisineTypeServices, IMapper mapper)
        {
            _restaurantCuisineTypeServices = restaurantCuisineTypeServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurantCuisineTypeAsync()
        {
            var restaurantCuisineTypes = await _restaurantCuisineTypeServices.GetAllRestaurantCuisineTypesService();
            var data=_mapper.Map<IEnumerable<DetailsRestaurantCuisineTypeDto>>
                                           (restaurantCuisineTypes);
            return Ok(data);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantCuisineTypeByIdAsync(int id)
        {
            var restaurantCuisineTypes = await _restaurantCuisineTypeServices.GetRestaurantCuisineTypeByIdService(id);
            if (restaurantCuisineTypes == null)
                return NotFound("Restaurant Cuisine Type not found.");

            var data = _mapper.Map<DetailsRestaurantCuisineTypeDto>
                                             (restaurantCuisineTypes);
            return Ok(data);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddRestaurantCuisineTypeAsync(AddAndEditRestaurantCuisineTypeDto restaurantCuisineTypeDto)
        {
            if (restaurantCuisineTypeDto == null)
                return BadRequest("Invalid data.");

            var restaurantCuisineTypes = new RestaurantCuisineType()
            {
                RestaurantId = restaurantCuisineTypeDto.RestaurantId,
                CuisineTypeId = restaurantCuisineTypeDto.CuisineTypeId
            };
            await _restaurantCuisineTypeServices.AddRestaurantCuisineTypeService(restaurantCuisineTypes);
            return Ok(restaurantCuisineTypes);
        }
      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurantCuisineTypeAsync(int id, AddAndEditRestaurantCuisineTypeDto restaurantCuisineTypeDto)
        {
            var restaurantCuisineTypes = await _restaurantCuisineTypeServices.GetRestaurantCuisineTypeByIdService(id);
            
            if (restaurantCuisineTypes == null)
                return NotFound("Restaurant Cuisine Type not found.");
            
            if(restaurantCuisineTypeDto == null)
                return BadRequest("Invalid data.");

            _mapper.Map(restaurantCuisineTypeDto, restaurantCuisineTypes);
           
            await _restaurantCuisineTypeServices.UpdateRestaurantCuisineTypeService(restaurantCuisineTypes);
            
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantCuisineTypeAsync(int id)
        {
            var restaurantCuisineTypes = await _restaurantCuisineTypeServices.GetRestaurantCuisineTypeByIdService(id);
            if (restaurantCuisineTypes == null)
                return NotFound("Restaurant Cuisine Type not found.");

            await _restaurantCuisineTypeServices.DeleteRestaurantCuisineTypeService(restaurantCuisineTypes);

            return Ok("Deleted Successfully");
        }
    }
}

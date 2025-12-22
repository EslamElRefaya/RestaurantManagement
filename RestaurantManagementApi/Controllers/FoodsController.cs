using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement_Applicatin.Services.Foods;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.Foods;

namespace RestaurantManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodServices _foodServices;
        private readonly IMapper _mapper;

        public FoodsController(IFoodServices foodServices, IMapper mapper)
        {
            _foodServices = foodServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFoodsAsync()
        {
            var foods = await _foodServices.GetAllFoodsService();
            if (foods == null || !foods.Any())
                return NotFound("No foods found.");
            return Ok(foods);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodByIdAsync(int id)
        {
            var food = await _foodServices.GetFoodByIdService(id);
            if (food == null)
                return NotFound($"Food with ID {id} not found.");
            return Ok(food);
        }
        [HttpPost]
        public async Task<IActionResult> AddFoodAsync(AddAndEditFoodDto foodDto)
        {
            if (foodDto == null)
                return BadRequest("Food data is null.");
            var food = _mapper.Map<Food>(foodDto);
            await _foodServices.AddFoodService(food);
            return Ok(food);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFoodAsync(int id, AddAndEditFoodDto foodDto)
        {
            var food = await _foodServices.GetFoodByIdService(id);
            if (food == null)
                return NotFound($"Food with ID {id} not found.");
            _mapper.Map(foodDto, food);
            await _foodServices.UpdateFoodService(food);
            return Ok(food);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodAsync(int id)
        {
            var food = await _foodServices.GetFoodByIdService(id);
            if (food == null)
                return NotFound($"Food with ID {id} not found.");
            await _foodServices.DeleteFoodService(food);
            return Ok($"Food with ID {id} has been deleted.");
        }
    }
}

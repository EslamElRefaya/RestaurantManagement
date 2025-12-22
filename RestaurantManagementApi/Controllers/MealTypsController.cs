using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement_Applicatin.Services.MealTypes;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.MealTypes;

namespace RestaurantManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealTypsController : ControllerBase
    {
        private readonly IMealTypeServices _mealTypeService;
        private readonly IMapper _mapper;

        public MealTypsController(IMealTypeServices mealTypeService, IMapper mapper)
        {
            _mealTypeService = mealTypeService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMealTypesAsync()
        {
            var mealTypes = await _mealTypeService.GetAllMealTypesService();
            return Ok(mealTypes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealTypeByIdAsync(int id)
        {
            var mealType = await _mealTypeService.GetMealTypeByIdService(id);
            if (mealType == null)
                return NotFound("No Meal Types Founded");

            return Ok(mealType);
        }
        [HttpPost]
        public async Task<IActionResult> AddMealTypeAsync(AddAndEditMealTypeDto mealTypeDto)
        {
            var mealType = _mapper.Map<MealType>(mealTypeDto);
            await _mealTypeService.AddMealTypeService(mealType);
            return Ok(mealType);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMealTypeAsync(int id, AddAndEditMealTypeDto mealTypeDto)
        {
            var mealType = await _mealTypeService.GetMealTypeByIdService(id);

            if (mealType == null)
                return NotFound("No Meal Types Founded");

            _mapper.Map(mealTypeDto, mealType);
            await _mealTypeService.UpdateMealTypeService(mealType);
            return Ok(mealType);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealTypeAsync(int id)
        {
            var mealType = await _mealTypeService.GetMealTypeByIdService(id);

            if (mealType == null)
                return NotFound("No Meal Types Founded");

            await _mealTypeService.DeleteMealTypeService(mealType);
            return Ok("Meal Type Deleted Successfully");
        }
    }
}

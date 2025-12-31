using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement_Applicatin.Services.CuisineTypes;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.CuisineTypes;

namespace RestaurantManagementApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineTypsController : ControllerBase
    {
        private readonly ICuisineTypeServices _cuisineTypeServices;
        private readonly IMapper _mapper;
        public CuisineTypsController(ICuisineTypeServices cuisineTypeServices, IMapper mapper)
        {
            _cuisineTypeServices = cuisineTypeServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCuisineTypesAsync()
        {
            var cuisineTypes = await _cuisineTypeServices.GetAllCuisineTypesService();
            if (cuisineTypes == null || !cuisineTypes.Any())
                return NotFound("No CuisineTypes added yet !!");

            var data = _mapper.Map<IEnumerable<DetailsCuisineTypeDto>>(cuisineTypes);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCuisineTypesByIdAsync(int id)
        {
            var cusineType = await _cuisineTypeServices.GetCuisineTypeByIdService(id);
            if (cusineType == null)
                return NotFound($"CuisineType with Id = {id} not found");

            var data = _mapper.Map<DetailsCuisineTypeDto>(cusineType);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddCuisineTypeAsync(AddAndEditCuisineTypeDto cuisineTypeDto)
        {
            if (cuisineTypeDto == null)
                return BadRequest("CuisineType is Required");

            var cuisineType = _mapper.Map<CuisineType>(cuisineTypeDto);
            await _cuisineTypeServices.AddCuisineTypeService(cuisineType);
            return Ok(cuisineType);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCuisineTypeAsync(int id, AddAndEditCuisineTypeDto cuisineTypeDto)
        {
            var cusineType = await _cuisineTypeServices.GetCuisineTypeByIdService(id);

            if (cusineType == null)
                return NotFound($"CuisineType with Id = {id} not found");

            if (cuisineTypeDto == null)
                return BadRequest("CuisineType is Required");

            _mapper.Map(cuisineTypeDto, cusineType);

            await _cuisineTypeServices.UpdateCuisineTypeService(cusineType);
            return Ok(cusineType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuisineTypeAsync(int id)
        {
            var cusineType = await _cuisineTypeServices.GetCuisineTypeByIdService(id);

            if (cusineType == null)
                return NotFound($"CuisineType with Id = {id} not found");

            await _cuisineTypeServices.DeleteCuisineTypeService(cusineType);
            var data = _mapper.Map<DetailsCuisineTypeDto>(cusineType);
            return Ok(data);
        }
    }
}

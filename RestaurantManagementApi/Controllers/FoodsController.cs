using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using RestaurantManagement_Applicatin.Services.Foods;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.Foods;

namespace RestaurantManagementApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodServices _foodServices;
        private readonly IMapper _mapper;
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png" };
        private const long _maxFileSize = 2 * 1024 * 1024; // 2MB

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
            var  data= _mapper.Map<IEnumerable<DetailsFoodDto>>(foods);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodByIdAsync(int id)
        {
            var food = await _foodServices.GetFoodByIdService(id);
            if (food == null)
                return NotFound($"Food with ID {id} not found.");
            var data = _mapper.Map<DetailsFoodDto>(food);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddFoodAsync([FromForm] AddAndEditFoodDto foodDto)
        {
            if (foodDto == null)
                return BadRequest("Food data is null.");

            if (foodDto.Image == null)
                return BadRequest("Image is required.");

            // check on size image
            if (foodDto.Image.Length > _maxFileSize)
                return BadRequest("Image size must not exceed 2MB.");

            // check on Extension image
            var extension = Path.GetExtension(foodDto.Image.FileName).ToLower();
            if (!_allowedExtensions.Contains(extension))
                return BadRequest("Only .jpg, .jpeg, .png images are allowed.");

            // create unique image name
            var imageName = $"{Guid.NewGuid()}{extension}";

            // path for image
            var imagePath = Path.Combine("wwwroot/images/foods", imageName);

            // save image on server
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await foodDto.Image.CopyToAsync(stream);
            }

            var food = _mapper.Map<Food>(foodDto);

            // image store in db
            food.URL = imageName;

            await _foodServices.AddFoodService(food);

            return Ok(food);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFoodAsync(int id, [FromForm] AddAndEditFoodDto foodDto)
        {
            var food = await _foodServices.GetFoodByIdService(id);
            if (food == null)
                return NotFound($"Food with ID {id} not found.");

            _mapper.Map(foodDto, food);

            // check on image if  updated
            if (foodDto.Image != null)
            {
                var extension = Path.GetExtension(foodDto.Image.FileName).ToLower();

                if (!_allowedExtensions.Contains(extension))
                    return BadRequest("Only .jpg, .jpeg, .png images are allowed.");

                if (foodDto.Image.Length > _maxFileSize)
                    return BadRequest("Image size must not exceed 2MB.");

                var imageName = $"{Guid.NewGuid()}{extension}";
                var imagePath = Path.Combine("wwwroot/images/foods", imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await foodDto.Image.CopyToAsync(stream);
                }

                // replace old image with new image
                food.URL = imageName;
            }

            await _foodServices.UpdateFoodService(food);
            return Ok(food);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodAsync(int id)
        {
            var food = await _foodServices.GetFoodByIdService(id);

            if (food == null)
                return NotFound($"Food with ID {id} not found.");

            // check if image saved on Db
            if (!string.IsNullOrEmpty(food.URL))
            {

                var imagePath = Path.Combine("wwwroot/images/foods", food.URL);


                //check if image Exists before delete
                if (System.IO.File.Exists(imagePath))
                {
                    //Delete image from server
                    System.IO.File.Delete(imagePath);
                }
            }
            await _foodServices.DeleteFoodService(food);

            return Ok($"Food with ID {id} and its image have been deleted.");
        }

    }
}

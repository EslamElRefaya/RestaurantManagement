using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement_Applicatin.Services.FoodReviews;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.FoodReviews;

namespace RestaurantManagementApi.Controllers
{
    [Authorize(Roles ="User")]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodReviewsController : ControllerBase
    {
        private readonly IFoodReviewServices _foodReviewServices;
        private readonly IMapper _mapper;
        public FoodReviewsController(IFoodReviewServices foodReviewServices, IMapper mapper)
        {
            _foodReviewServices = foodReviewServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFoodReviewsAsync()
        {
            var foodReviews = await _foodReviewServices.GetAllFoodReviewsService();
            var data = _mapper.Map<IEnumerable<DetailsFoodReviewDto>>(foodReviews);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodReviewByIdAsync(int id)
        {
            var foodReview = await _foodReviewServices.GetFoodReviewByIdService(id);
            if (foodReview == null)
                return NotFound($"Food Review with ID {id} not found.");

            var data = _mapper.Map<DetailsFoodReviewDto>(foodReview);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddFoodReviewAsync(AddAndEditFoodReviewDto foodReviewDto)
        {
            if (foodReviewDto == null)
                return BadRequest("Food Review data is null.");

            var foodReview = _mapper.Map<FoodReview>(foodReviewDto);

            await _foodReviewServices.AddFoodReviewService(foodReview);
            return Ok(foodReview);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFoodReviewAsync(int id, AddAndEditFoodReviewDto foodReviewDto)
        {
            var foodReview = await _foodReviewServices.GetFoodReviewByIdService(id);

            if (foodReview == null)
                return NotFound($"Food Review with ID {id} not found.");
            _mapper.Map(foodReviewDto, foodReview);
            await _foodReviewServices.UpdateFoodReviewService(foodReview);
            return Ok(foodReview);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodReviewAsync(int id)
        {
            var foodReview = await _foodReviewServices.GetFoodReviewByIdService(id);

            if (foodReview == null)
                return NotFound($"Food Review with ID {id} not found.");

            await _foodReviewServices.DeleteFoodReviewService(foodReview);
            return Ok("Delete Operation is successfully");
        }
    }
}

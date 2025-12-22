using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement_Applicatin.Services.FoodReviews;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.FoodReviews;

namespace RestaurantManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodReviewsController : ControllerBase
    {
        private readonly IFoodReviewServices _foodReviewServices;

        public FoodReviewsController(IFoodReviewServices foodReviewServices)
        {
            _foodReviewServices = foodReviewServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFoodReviewsAsync()
        {
            var foodReviews = await _foodReviewServices.GetAllFoodReviewsService();
            return Ok(foodReviews);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodReviewByIdAsync(int id)
        {
            var foodReview = await _foodReviewServices.GetFoodReviewByIdService(id);
            if (foodReview == null)
                return NotFound($"Food Review with ID {id} not found.");

            return Ok(foodReview);
        }
        [HttpPost]
        public async Task<IActionResult> AddFoodReviewAsync(AddAndEditFoodReviewDto foodReviewDto)
        {
            if(foodReviewDto == null)
                return BadRequest("Food Review data is null.");

            var foodReview = new FoodReview
            {
                Description = foodReviewDto.Description,
                FoodId = foodReviewDto.FoodId
            };

            await _foodReviewServices.AddFoodReviewService(foodReview);
            return Ok(foodReview);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFoodReviewAsync(int id, AddAndEditFoodReviewDto foodReviewDto)
        {
            var foodReview = await _foodReviewServices.GetFoodReviewByIdService(id);
           
            if (foodReview == null)
                return NotFound($"Food Review with ID {id} not found.");

            foodReview.Description = foodReviewDto.Description;
            foodReview.FoodId = foodReviewDto.FoodId;
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
            return NoContent();
        }
    }
}

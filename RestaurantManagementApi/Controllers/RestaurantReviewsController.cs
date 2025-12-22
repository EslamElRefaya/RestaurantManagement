using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement_Applicatin.Services.RestaurantReviews;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.RestaurantReviews;

namespace RestaurantManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantReviewsController : ControllerBase
    {
        private readonly IRestaurantReviewService _restaurantReviewService;
        private readonly IMapper _mapper;
        public RestaurantReviewsController(IRestaurantReviewService restaurantReviewService, IMapper mapper)
        {
            _restaurantReviewService = restaurantReviewService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurantReviewsAsync()
        {
            var restaurantReviews = await _restaurantReviewService.GetAllRestaurantReviewsService();
            var data=_mapper.Map<IEnumerable<DetailsRestaurantReviewDto>>(restaurantReviews);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantReviewByIdAsync(int id)
        {
            var restaurantReview = await _restaurantReviewService.GetRestaurantReviewByIdService(id);
            if (restaurantReview == null)
            {
                return NotFound("RestaurantReview is not been founded");
            }
            var data = _mapper.Map<DetailsRestaurantReviewDto>(restaurantReview);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddRestaurantReviewAsync(AddAndEditRestaurantReviewDto restaurantReviewDto)
        {
            if (restaurantReviewDto == null)
                return BadRequest("RestaurantReview data is null");
            var restaurantReview=_mapper.Map<RestaurantReview>(restaurantReviewDto);
            await _restaurantReviewService.AddRestaurantReviewService(restaurantReview);
            
            return Ok(restaurantReview);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurantReviewAsync(int id, AddAndEditRestaurantReviewDto restaurantReviewDto)
        {
            var restaurantReview = await _restaurantReviewService.GetRestaurantReviewByIdService(id);
            if (restaurantReview == null)
                return NotFound("RestaurantReview is not been founded");
            
            if (restaurantReviewDto == null)
                return BadRequest("RestaurantReview data is null");

           _mapper.Map(restaurantReviewDto, restaurantReview);
            await _restaurantReviewService.UpdateRestaurantReviewService(restaurantReview);
            return Ok("RestaurantReview has been updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantReviewAsync(int id)
        {
            var restaurantReview = await _restaurantReviewService.GetRestaurantReviewByIdService(id);
            if (restaurantReview == null)
                return NotFound("RestaurantReview is not been founded");
            await _restaurantReviewService.DeleteRestaurantReviewService(restaurantReview);
            return Ok("RestaurantReview has been deleted successfully");
        }
    }


}

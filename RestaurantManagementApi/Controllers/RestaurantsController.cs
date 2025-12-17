using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRestaurants()
        {
            return Ok(new { Message = "List of restaurants will be here." });
        }
    }
}

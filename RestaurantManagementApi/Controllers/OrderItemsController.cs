using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Applicatin.Services.Foods;
using RestaurantManagement_Applicatin.Services.OrderItems;
using RestaurantManagement_Applicatin.Services.Payments;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.OrderItems;

namespace RestaurantManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IFoodServices _foodService;
        private readonly IMapper _mapper;
        public OrderItemsController(IOrderItemService orderItemService,IMapper mapper, IFoodServices foodService)
        {
            _orderItemService = orderItemService;
            _mapper = mapper;
            _foodService = foodService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderItemsAsync()
        {
            var orderItems = await _orderItemService.GetAllOrderItemsService();
            var data = _mapper.Map<IEnumerable<DetailsOrderItemDto>>(orderItems);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemByIdAsync(int id)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdService(id);
            if (orderItem == null)
                return NotFound($"Order Item with id {id} not found.");
            var data = _mapper.Map<DetailsOrderItemDto>(orderItem);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrderItemAsync(AddAndEditOrderItemDto addOrderItemDto)
        { 
            if (ModelState.IsValid)
            {
                var orderItem = _mapper.Map<OrderItem>(addOrderItemDto);
              
                //// get food price explicitly to avoid null reference and Set Price from Food Tb
                var food = await _foodService.GetFoodByIdService(addOrderItemDto.FoodId);
                
                if (food == null)
                    return NotFound($"Food with id {addOrderItemDto.FoodId} not found.");
                
                orderItem.Price = food.Price;

                await _orderItemService.AddOrderItemService(orderItem);

                // to avoid Serialization issues
                var data = _mapper.Map<DetailsOrderItemDto>(orderItem);
                return Ok(data);
            }
            else
                return BadRequest(ModelState);
           
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItemAsync(int id, AddAndEditOrderItemDto addOrderItemDto)
        {
            if(ModelState.IsValid)
            {
                var orderItem = await _orderItemService.GetOrderItemByIdService(id);
               
                if (orderItem == null)
                    return NotFound($"Order Item with id {id} not found.");
                
                _mapper.Map(addOrderItemDto, orderItem);

                //// get food price explicitly to avoid null reference and update Price from Food Tb
                var food = await _foodService.GetFoodByIdService(addOrderItemDto.FoodId);

                if (food == null)
                    return NotFound($"Food with id {addOrderItemDto.FoodId} not found.");

                orderItem.Price = food.Price;

                await _orderItemService.UpdateOrderItemService(orderItem);
               
                // to avoid Serialization issues
                var data = _mapper.Map<DetailsOrderItemDto>(orderItem);
                return Ok(data);
            }
            else
                return BadRequest(ModelState);
           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItemAsync(int id)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdService(id);
            if (orderItem == null)
                return NotFound($"Order Item with id {id} not found.");
            await _orderItemService.DeleteOrderItemService(orderItem);
            return Ok($"Order Item with id {id} has been deleted.");
        }

       
    }
}

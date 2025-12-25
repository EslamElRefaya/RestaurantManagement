using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement_Applicatin.Services.Orders;
using RestaurantManagement_Applicatin.Services.Payments;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.Orders;
using static NuGet.Packaging.PackagingConstants;


namespace RestaurantManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderServices orderServices, IMapper mapper, IPaymentService paymentService)
        {
            _orderServices = orderServices;
            _mapper = mapper;
            _paymentService = paymentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orders = await _orderServices.GetAllOrdersService();
            if(orders==null)
                return NotFound("No data added yet.");

            var data=_mapper.Map<IEnumerable<DetailsOrderDto>>(orders);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            var order = await _orderServices.GetOrderByIdService(id);
            if (order == null)
                return NotFound($"Order with Id: {id} not found");

            var data = _mapper.Map<DetailsOrderDto>(order);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(AddOrderDto addOrderDto)
        {
            var order = new Order
            {
                RestaurantId = addOrderDto.RestaurantId,
                Notes = addOrderDto.Notes,
            };
            await _orderServices.AddOrderService(order);
            return Ok(order);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, EditOrderDto editOrderDto)
        {
            var order = await _orderServices.GetOrderByIdService(id);
           
            if (order == null)
                return NotFound($"Order with Id: {id} not found");
            
            if(editOrderDto == null)
                return BadRequest("Invalid order data.");

            var data = _mapper.Map(editOrderDto, order);

            await _orderServices.UpdateOrderService(order);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var order = await _orderServices.GetOrderByIdService(id);
            if (order == null)
                return NotFound($"Order with Id: {id} not found");
            await _orderServices.DeleteOrderService(order);
            return Ok("Delete is Successed");
        }

        [HttpPost("Payment/{ordrId}")]
        public async Task<IActionResult> PayAsync(int ordrId)
        {
            await _paymentService.PayService(ordrId);
            return Ok("Paid successfully");
        }
    }
}

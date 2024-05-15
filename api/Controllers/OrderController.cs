using api.Dtos.Order;
using api.Dtos.Product;
using api.Dtos.Status;
using api.Entity;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IStatusRepository _statusRepo;
        private readonly IOrderDetailRepository _orderDetailRepo;
        public OrderController(IOrderRepository orderRepo, IStatusRepository statusRepo, IOrderDetailRepository orderDetailRepo)
        {
            _orderRepo = orderRepo;
            _statusRepo = statusRepo;
            _orderDetailRepo = orderDetailRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
        {
            try
            {
                if (orderDto == null)
                {
                    return BadRequest();
                }
                var today = DateOnly.FromDateTime(DateTime.Now);
                var createOrder = new CreateOrderDto
                {
                    OrderTime = today,
                    StatusId = 1,
                    UserId = orderDto.UserId,
                };
                var order = await _orderRepo.Create(createOrder.ToOrder());
                if (order != null)
                {
                    return Ok(order);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OrderQueryObject query)
        {
            try
            {
                List<Order> orders = await _orderRepo.GetAll(query);
                if (orders == null)
                {
                    return NotFound();
                }
                var count = _orderRepo.GetCount(query);
                var pageCount = count % query.pageSize == 0 ? count / query.pageSize : count / query.pageSize + 1;
                return Ok(new ResponseOrderDto
                {
                    page = query.page,
                    pageSize = query.pageSize,
                    pageCount = pageCount,
                    orders = orders.MapToDtos()
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPut("{orderId:long}")]
        public async Task<IActionResult> Update([FromRoute] long orderId, UpdateOrderDto orderDto)
        {
            try
            {
                var check = await _statusRepo.Check(orderDto.StatusId);
                if (check != null)
                {
                    var order = await _orderRepo.Update(orderId, orderDto);
                    if (order != null)
                    {
                        return Ok(order);
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpDelete("{orderId:long}")]
        public async Task<IActionResult> Delete([FromRoute] long orderId)
        {
            try
            {
                await _orderDetailRepo.Delete(orderId);
                var order = await _orderRepo.Delete(orderId);
                if (order != null)
                {
                    return Ok(order);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

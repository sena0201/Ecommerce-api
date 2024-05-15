using api.Dtos.OrderDetail;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepo;
        public OrderDetailController(IOrderDetailRepository orderDetailRepo)
        {
            _orderDetailRepo = orderDetailRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDetailDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest();
                }
                var OD = await _orderDetailRepo.Create(dto.ToOrderDetail());
                if (OD == null)
                {
                    return BadRequest();
                }
                return Ok(OD);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}

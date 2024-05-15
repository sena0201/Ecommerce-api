using api.Dtos.Cart;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepo;

        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        [HttpGet("{userId:long}")]
        public async Task<IActionResult> Get([FromRoute] long userId)
        {
            try
            {
                var carts = await _cartRepo.Get(userId);
                if (carts == null)
                {
                    return NotFound();
                }
                return Ok(carts);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] NewItemDto itemDto)
        {
            try
            {
                var cart = await _cartRepo.Add(itemDto.ToCart());
                return Ok(cart!.ToCartDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut("{cartId:long}")]
        public async Task<IActionResult> Update([FromRoute] long cartId, [FromBody] UpdateItemDto itemDto)
        {
            try
            {
                if (itemDto.Quantity <= 0)
                {
                    var c = await _cartRepo.Delete(cartId);
                    if (c == null)
                    {
                        return NotFound();
                    }
                    return Ok(c);
                }
                var cart = await _cartRepo.Update(cartId, itemDto);
                if (cart == null)
                {
                    return NotFound();
                }
                return Ok(cart);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpDelete("{cartId:long}")]
        public async Task<IActionResult> Delete([FromRoute] long cartId)
        {
            try
            {
                var cart = await _cartRepo.Delete(cartId);
                if (cart == null)
                {
                    return NotFound();
                }
                return Ok(cart);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}

using api.Dtos.Cart;
using api.Entity;

namespace api.Mappers
{
    public static class CartMappers
    {
        public static Cart ToCart(this NewItemDto cartDto)
        {
            return new Cart
            {
                ProductId = cartDto.ProductId,
                Quantity = cartDto.Quantity,
                UserId = cartDto.UserId,
            };
        }

        public static CartDto ToCartDto(this Cart cart)
        {
            return new CartDto
            {
                ProductId = cart.ProductId,
                Quantity = cart.Quantity,
                UserId = cart.UserId,
            };
        }
        public static List<CartDto> MapToDto(this List<Cart> carts)
        {
            if (carts == null)
            {
                return new List<CartDto>();
            }
            return carts.Select(cart => new CartDto
            {
                CartId = cart.CartId,
                ProductId = cart.ProductId,
                Quantity = cart.Quantity,
                UserId = cart.UserId,
            }).ToList();
        }
    }
}

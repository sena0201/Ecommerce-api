using api.Dtos.Cart;
using api.Entity;

namespace api.Interfaces
{
    public interface ICartRepository
    {
        public Task<Cart?> Add(Cart cart);
        public Task<Cart?> Update(long cartId, UpdateItemDto itemDto);
        public Task<Cart?> Delete(long cartId);
        public Task<List<Cart>?> Get(long userId);
    }
}

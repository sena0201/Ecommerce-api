using api.Data;
using api.Dtos.Cart;
using api.Entity;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDBContext _context;

        public CartRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Cart?> Add(Cart cart)
        {
            var c = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == cart.UserId && c.ProductId == cart.ProductId);
            if (c == null)
            {
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
                return cart;
            }
            c.Quantity += cart.Quantity;
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task<Cart?> Delete(long cartId)
        {
            var c = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == cartId);
            if (c == null)
            {
                return null;
            }
            _context.Carts.Remove(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task<List<Cart>?> Get(long userId)
        {
            var carts = await _context.Carts.Include(c => c.Product).ThenInclude(p => p.Photos).Where(c => c.UserId == userId).ToListAsync();
            return carts;
        }

        public async Task<Cart?> Update(long cartId, UpdateItemDto itemDto)
        {
            var c = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == cartId);
            if (c == null)
            {
                return null;
            }
            c.Quantity = itemDto.Quantity;
            await _context.SaveChangesAsync();
            return c;
        }
    }
}

using api.Data;
using api.Entity;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderDetailRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<OrderDetail?> Create(OrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                return null;
            }

            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<List<OrderDetail>?> Delete(long orderId)
        {
            var orderDetails = _context.OrderDetails.Where(o => o.OrderId == orderId).ToList();
            if (orderDetails == null)
            {
                return null;
            }
            orderDetails.ForEach(o =>
            {
                _context.OrderDetails.Remove(o);
            });
            await _context.SaveChangesAsync();
            return orderDetails;
        }
    }
}

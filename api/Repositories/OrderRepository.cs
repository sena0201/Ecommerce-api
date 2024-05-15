using api.Data;
using api.Dtos.Order;
using api.Dtos.Product;
using api.Entity;
using api.Helpers;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Order?> Create(Order order)
        {
            if (order == null) { return null; }

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> Delete(long orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (order == null)
            {
                return null;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAll(OrderQueryObject query)
        {
            var orders = _context.Orders.AsQueryable();
            /*if (!string.IsNullOrWhiteSpace(query.searchValue))
            {
                orders = _context.Products.Where(p => p.ProductName!.Contains(query.searchValue));
            }*/
            var nextNumber = (query.page - 1) * query.pageSize;
            return await orders.Skip(nextNumber).Take(query.pageSize).ToListAsync();
        }

        public int GetCount(OrderQueryObject query)
        {
            var orders = _context.Orders.AsQueryable();
            /*if (!string.IsNullOrWhiteSpace(query.searchValue))
            {
                products = _context.Products.Where(p => p.ProductName!.Contains(query.searchValue));
            }*/
            return orders.Count();
        }

        public async Task<Order?> Update(long orderId, UpdateOrderDto orderDto)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (order == null)
            {
                return null;
            }
            order.StatusId = orderDto.StatusId;

            await _context.SaveChangesAsync();
            return order;
        }
    }
}

using api.Dtos.Order;
using api.Entity;
using api.Helpers;

namespace api.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order?> Create(Order order);
        public Task<List<Order>> GetAll(OrderQueryObject query);
        public Task<Order?> Update(long orderId, UpdateOrderDto orderDto);
        public Task<Order?> Delete(long orderId);
        public int GetCount(OrderQueryObject query);
    }
}

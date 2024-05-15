using api.Entity;

namespace api.Interfaces
{
    public interface IOrderDetailRepository
    {
        public Task<OrderDetail?> Create(OrderDetail orderDetail);
        public Task<List<OrderDetail>?> Delete(long orderId);
    }
}

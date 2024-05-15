using api.Dtos.OrderDetail;
using api.Entity;

namespace api.Mappers
{
    public static class OrderDetailMappers
    {
        public static OrderDetail ToOrderDetail(this CreateOrderDetailDto dto)
        {
            return new OrderDetail
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
            };
        }
    }
}

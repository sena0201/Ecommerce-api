using api.Dtos.Order;
using api.Dtos.Product;
using api.Entity;

namespace api.Mappers
{
    public static class OrderMappers
    {
        public static Order ToOrder(this OrderDto orderDto, DateOnly orderTime)
        {
            return new Order
            {
                UserId = orderDto.UserId,
                OrderTime = orderTime
            };
        }
        public static Order ToOrder(this CreateOrderDto orderDto)
        {
            return new Order
            {
                OrderTime = orderDto.OrderTime,
                UserId = orderDto.UserId,
                StatusId = orderDto.StatusId
            };
        }
        public static List<OrderDto> MapToDtos(this List<Order> orders)
        {
            if (orders == null)
            {
                return new List<OrderDto>();
            }

            return orders.Select(order => new OrderDto
            {
                UserId = order.UserId,
                OrderId = order.OrderId,
                StatusId = order.StatusId,
                OrderTime = order.OrderTime
            }).ToList();
        }
    }
}

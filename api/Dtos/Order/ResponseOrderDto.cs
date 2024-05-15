using api.Dtos.Product;

namespace api.Dtos.Order
{
    public class ResponseOrderDto : ResponseDto
    {
        public List<OrderDto> orders { get; set; }
    }
}

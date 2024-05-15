namespace api.Dtos.OrderDetail
{
    public class CreateOrderDetailDto
    {
        public long? OrderId { get; set; }

        public long? ProductId { get; set; }

        public long? Quantity { get; set; }
    }
}

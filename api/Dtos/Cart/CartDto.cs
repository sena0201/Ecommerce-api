namespace api.Dtos.Cart
{
    public class CartDto
    {
        public long CartId { get; set; }

        public long UserId { get; set; }

        public long? ProductId { get; set; }

        public long? Quantity { get; set; }

    }
}

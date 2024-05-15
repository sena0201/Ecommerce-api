namespace api.Dtos.Cart
{
    public class NewItemDto
    {
        public long UserId { get; set; }

        public long? ProductId { get; set; }

        public long? Quantity { get; set; }
    }
}

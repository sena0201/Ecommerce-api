namespace api.Dtos.Order
{
    public class OrderDto
    {
        public long OrderId { get; set; }

        public long? UserId { get; set; }

        public DateOnly? OrderTime { get; set; }

        public long StatusId { get; set; }
    }
}

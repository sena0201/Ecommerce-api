namespace api.Dtos.Order
{
    public class CreateOrderDto
    {
        public long? UserId { get; set; }

        public DateOnly? OrderTime { get; set; }

        public long StatusId { get; set; }
    }
}

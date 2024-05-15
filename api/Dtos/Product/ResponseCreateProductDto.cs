namespace api.Dtos.Product
{
    public class ResponseCreateProductDto
    {
        public bool Success { get; set; }
        public string message { get; set; }
        public ProductDto? product { get; set; }
    }
}

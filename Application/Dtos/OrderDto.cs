namespace Application.Dtos
{
    public class OrderDto
    {
        public int ClientId { get; set; }
        public ICollection<OrderDetailDto> OrderDetail { get; set; }
    }
}

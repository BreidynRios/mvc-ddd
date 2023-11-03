namespace Application.Dtos
{
    public class OrderDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

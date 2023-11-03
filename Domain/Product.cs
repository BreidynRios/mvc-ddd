namespace Domain
{
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

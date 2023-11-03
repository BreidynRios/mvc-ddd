namespace Domain
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

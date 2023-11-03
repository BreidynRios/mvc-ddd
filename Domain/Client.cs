namespace Domain
{
    public class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
using Domain;

namespace Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task Save(Order order);
    }
}

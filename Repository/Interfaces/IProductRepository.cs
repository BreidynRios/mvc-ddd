using Domain;

namespace Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> List();
    }
}

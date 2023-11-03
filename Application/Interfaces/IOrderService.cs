using Application.Dtos;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<bool> Save(OrderDto order);
    }
}

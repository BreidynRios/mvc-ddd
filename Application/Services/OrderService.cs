using Application.Dtos;
using Application.Interfaces;
using Domain;
using Persistence.Context;
using Repository.Interfaces;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Save(OrderDto OrderDto)
        {
            if (OrderDto.OrderDetail == null || !OrderDto.OrderDetail.Any())
                return false;

            var orderDetail = new List<OrderDetail>();
            foreach (var item in OrderDto.OrderDetail)
            {
                orderDetail.Add(new OrderDetail
                {
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Description = item.Description,
                    ProductId = item.ProductId,
                    SubTotal = item.Quantity * item.UnitPrice
                });
            }
            var Order = new Order
            {
                ClientId = OrderDto.ClientId,
                Date = DateTime.Now,
                Total = orderDetail.Sum(pd => pd.SubTotal),
                OrderDetails = orderDetail
            };

            await _orderRepository.Save(Order);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

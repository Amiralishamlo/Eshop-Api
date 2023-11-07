using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.RemoveItem
{
    public class RemoveOrderItemCommandHandler : IBaseCommandHandler<RemoveOrderItemCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoveOrderItemCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if(orders == null)
                return OperationResult.NotFound();
            orders.RemoveItem(request.UserId);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}

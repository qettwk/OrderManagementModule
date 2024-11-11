using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteOrderCommand : IRequest // response?
    {
        public Guid Id { get; set; }
    }

    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand> // что возвращать
    {
        private readonly OrderDbContext _orderDbContext;
        public DeleteOrderHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }
        public async Task Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderDbContext.Orders.FindAsync(command.Id);
            if (order != null)
            {
                order.Cancellation = true;
                await _orderDbContext.SaveChangesAsync();
            }
        }
    }
}

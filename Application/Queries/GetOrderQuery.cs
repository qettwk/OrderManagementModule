
using Domain;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetOrderQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }

    public class GerOrderHandler : IRequestHandler<GetOrderQuery, Order>
    {
        private readonly OrderDbContext _orderDbContext;
        public GerOrderHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }
        public async Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var orderFound = await _orderDbContext.Orders.Where(o => o.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            Order order = new Order
            {
                PaymentConfirmation = orderFound.PaymentConfirmation
            };
            return order;
        }
    }
}

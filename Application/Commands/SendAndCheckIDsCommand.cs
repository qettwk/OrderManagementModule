using Application.Commands.ViewModels;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class SendAndCheckIDsCommand : IRequest<List<Guid>>
    {
        public Guid OrderId { get; set; }
        public List<Guid> AutomobileIDs { get; set; }
        CheckedAutoIDsDTO checkedAutoIDsDTO { get; set; }
    }

    public class SendAndCheckIDsHandler : IRequestHandler<SendAndCheckIDsCommand, List<Guid>>
    {
        //private readonly IMediator _mediator;
        private readonly HttpClient _httpClient;
        private readonly OrderDbContext _orderDbContext;
        public SendAndCheckIDsHandler(IMediator mediator, HttpClient httpClient, OrderDbContext orderDbCotext)
        {
            //_mediator = mediator;
            _httpClient = httpClient;
            _orderDbContext = orderDbCotext;
        }

        public async Task<List<Guid>> Handle(SendAndCheckIDsCommand command, CancellationToken cancellationToken)
        {
            var json = JsonSerializer.Serialize(command.AutomobileIDs); 
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5048/api/Warehouse/SendAutomobilesToOrder", content);

            //if (response.IsSuccessStatusCode)
            //{
            //    response.Content
            //}

            //checkedAutoIDsDTO.automobileIDs
            

            //if (answer.Excepted == false)
            //{
            //    var order = await _orderDbContext.Orders.FirstOrDefaultAsync(o => o.Id == command.OrderId);
            //    order.AutomobilesId = command.AutomobileIDs;
            //    _orderDbContext.SaveChanges();
            //    return (List<Guid>)order.AutomobilesId;
            //}
            //if (answer.Excepted == true)
            //{
            //    return BadRequest(answer.automobileIDs);
            //}

            return new List<Guid>();
        }
    


     }
}

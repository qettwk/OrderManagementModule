using Application.Commands;
using Application.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Application.Commands.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly HttpClient _httpClient;
        public OrderController(IMediator mediator, HttpClient httpClient)
        {
            _mediator = mediator;
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<ActionResult<List<Guid>>> CreateOrder([FromQuery] Guid customerID, [FromQuery] List<Guid> automobilesIDs)
        {
            var commandSend = new AddOrderCommand
            {
               orderAddDTO = new OrderAddDTO
               { 
                   CustomerID = customerID,
                   AutomobileIDs = automobilesIDs
               }
            };
            await _mediator.Send(commandSend);
            return new List<Guid>();
        }

        //[HttpPut]
        //public async Task<IActionResult> AddAutomobilesInOrder([FromQuery] List<Guid> AutomobilesId)
        //{


        //}

        //[HttpPut]
        //public async Task<IActionResult> AddCustomerInOrder([FromQuery] List<Guid> AutomobilesId)
        //{


        //}


        //[HttpGet("{orderId}")]
        //public Task<OrderDTO> GetOrder(Guid orderId)
        //{
        //    return _mediator.Send(new GetOrderQuery { Id = orderId });
        //}




        [HttpPost]
        public async Task<ActionResult> AddOrder(AddOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteOrder(Guid OrderId)
        {
            var command = new DeleteOrderCommand
            {
                Id = OrderId
            };
            await _mediator.Send(command);

            return Ok();
        }
    }
}

using Application.Commands.ViewModels;
using Domain;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Commands
{
    public class AddOrderCommand : IRequest<Guid>
    {
        public OrderAddDTO orderAddDTO { get; set; }
    }

    public class AddOrderHandler : IRequestHandler<AddOrderCommand, Guid>
    {
        private readonly HttpClient _httpClient;
        private readonly OrderDbContext _orderDbContext;
        public AddOrderHandler(HttpClient httpClient, OrderDbContext orderDbCotext)
        {
            _httpClient = httpClient;
            _orderDbContext = orderDbCotext;
        }

        public async Task<Guid> Handle(AddOrderCommand command, CancellationToken cancellationToken)
        {
            Order order = new Order
            {
                Id = new Guid(),
            };

            // automobiles
            var json = JsonSerializer.Serialize(command.orderAddDTO.AutomobileIDs);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5048/api/Warehouse/SendAutomobilesToOrder", content);
            string responseData = await response.Content.ReadAsStringAsync();
            var checkedAutoIDsDTO = JsonSerializer.Deserialize<CheckedAutoIDsDTO>(responseData);

            if (checkedAutoIDsDTO.Excepted == false)
            {
                order.AutomobilesId = checkedAutoIDsDTO.automobileIDs;
            }

            // customer
            
            response = await _httpClient.GetAsync($"http://localhost:5052/api/Customer/SendCustomerIDToOrder/{command.orderAddDTO.CustomerID}");
            responseData = await response.Content.ReadAsStringAsync();
            var checkedCustomerIDDTO = JsonSerializer.Deserialize<CheckedCustomerIDDTO>(responseData);

            if (checkedCustomerIDDTO.Excepted == false)
            {
                order.CustomerID = checkedCustomerIDDTO.id;
            }

            await _orderDbContext.Orders.AddAsync(order);
            await _orderDbContext.SaveChangesAsync();

            return order.Id;
        }
    }
}

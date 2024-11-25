using Application.Commands.ViewModels;
using Application.Queries.ViewModels;
using Domain;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using RabbitMQ.Client;

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
        public Guid CustomerID { get; set; }
        public OrderAddAutomobilesDTO orderAddAutomobilesDTO { get; set; }
        // public decimal Discount { get; set; }
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
                Id = Guid.NewGuid()
            };
            // customer
            OrderAndCustomerIDsDTO orderAndCustomerIDsDTO = new OrderAndCustomerIDsDTO
            {
                CustomerID = (Guid)command.CustomerID,
                OrderID = order.Id
            };

            var json = JsonSerializer.Serialize(orderAndCustomerIDsDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            // response = await _httpClient.GetAsync($"http://localhost:5052/api/Customer/SendCustomerIDToOrder/{command.CustomerID}");
            var response = await _httpClient.PostAsync("http://localhost:5052/api/Customer/SendCustomerIDToOrder/", content);
            var responseData = await response.Content.ReadAsStringAsync();
            var checkedCustomerIDDTO = JsonSerializer.Deserialize<CheckedCustomerIDDTO>(responseData);


            // automobiles ///////////////////////////////
            CheckAutoIDsAndDiscountDTO checkAutoIDsAndDiscountDTO = new CheckAutoIDsAndDiscountDTO();

            checkAutoIDsAndDiscountDTO.AutomobileIDsAndCountsDTO = command.orderAddAutomobilesDTO.AutomobileIDsAndCountsDTO;

            if (checkedCustomerIDDTO.dateOfBirth.Day == DateOnly.FromDateTime(DateTime.Now).Day
                && checkedCustomerIDDTO.dateOfBirth.Month == DateOnly.FromDateTime(DateTime.Now).Month)
            {
                checkAutoIDsAndDiscountDTO.Discount = 10;
            }

            json = JsonSerializer.Serialize(checkAutoIDsAndDiscountDTO);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await _httpClient.PostAsync("http://localhost:5048/api/Warehouse/SendAutomobilesToOrder", content);
            responseData = await response.Content.ReadAsStringAsync();
            var CheckedAutoIDsDTO = JsonSerializer.Deserialize<CheckedAutoIDsDTO>(responseData);


            if (CheckedAutoIDsDTO.excepted == false)
            {

                order.AutomobilesId = command.orderAddAutomobilesDTO.AutomobileIDsAndCountsDTO
                    .Select(dto => dto.AutomobileID)
                        .ToList();
                order.TotalSum = CheckedAutoIDsDTO.totalSum;

                // заполнение дополнительной таблицы, нужной для хранения количества автомобилей в заказе
                foreach (var auto in command.orderAddAutomobilesDTO.AutomobileIDsAndCountsDTO)
                {
                    var automobileCountInOrder = new AutomobileCountInOrder()
                    {
                        OrderID = order.Id,
                        ID = Guid.NewGuid(),
                        AutomobileID = auto.AutomobileID,
                        AutomobileCount = auto.count
                    };
                    await _orderDbContext.automobileCountInOrders.AddAsync(automobileCountInOrder);
                }
                await _orderDbContext.Orders.AddAsync(order);
                await _orderDbContext.SaveChangesAsync();
            }
            else
            {
                return Guid.Empty;
            }


            return order.Id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ViewModels
{
    public class OrderAddCustomerDTO
    {
        public Guid? CustomerID { get; set; }
        public Guid? OrderID { get; set; }
    }
}

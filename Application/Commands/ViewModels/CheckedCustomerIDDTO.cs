using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ViewModels
{
    public class CheckedCustomerIDDTO
    {
        public bool Excepted { get; set; }
        public Guid id { get; set; }
    }
}

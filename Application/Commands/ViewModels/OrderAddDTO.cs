using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ViewModels
{
    public class OrderAddDTO
    {
        public List<Guid> AutomobileIDs { get; set; }
        public Guid? CustomerID { get; set; }
    }
}

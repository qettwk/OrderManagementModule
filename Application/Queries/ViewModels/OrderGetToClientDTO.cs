using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ViewModels
{
    public class OrderGetToClientDTO
    {
        public Guid Id { get; set; }

        public bool PaymentConfirmation { get; set; }
        public decimal TotalSum { get; set; }

        public ICollection<Guid>? AutomobilesId { get; set; } 
        public ICollection<string> AutomobilesName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ViewModels
{
    public class OrderEditDTO
    {
        public Guid Id { get; set; }


        public bool IssuedToClient { get; set; }
        public bool PaymentConfirmation { get; set; }
        public bool Cancellation { get; set; } // SoftDeleted

        public ICollection<Guid>? AutomobilesId { get; set; }
        public Guid? CustomerID { get; set; }
    }
}

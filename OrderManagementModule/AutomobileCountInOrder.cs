using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AutomobileCountInOrder
    {
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public Guid AutomobileID { get; set; }
        public int AutomobileCount { get; set; }
    }
}

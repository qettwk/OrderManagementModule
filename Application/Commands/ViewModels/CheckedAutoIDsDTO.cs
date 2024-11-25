using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ViewModels
{
    public class CheckedAutoIDsDTO
    {
        public bool excepted { get; set; }
        public List<Guid> automobileIDs { get; set; } = new List<Guid>();
        public List<int> counts { get; set; } = new List<int>();
        public decimal totalSum { get; set; }
    }
}

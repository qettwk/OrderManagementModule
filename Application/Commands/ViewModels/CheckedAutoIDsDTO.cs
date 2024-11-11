using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ViewModels
{
    public class CheckedAutoIDsDTO
    {
        public bool Excepted { get; set; }
        public ICollection<Guid> automobileIDs { get; set; }
    }
}

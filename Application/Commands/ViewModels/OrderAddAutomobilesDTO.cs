using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ViewModels
{
    public class OrderAddAutomobilesDTO
    {
        public List<AutomobileIDsAndCountsDTO> AutomobileIDsAndCountsDTO { get; set; } = new List<AutomobileIDsAndCountsDTO>();
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.EMS.Business.ShipmentReport
{
    public class WeeklyShipmentStatusVM
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }
        public List<SelectListItem> DDLYear { get; set; }
        public List<SelectListItem> DDLMonth { get; set; }
        public List<SelectListItem> DDLWeek { get; set; }
    }
}

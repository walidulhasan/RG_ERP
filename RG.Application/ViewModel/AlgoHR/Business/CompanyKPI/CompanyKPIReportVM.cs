using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.CompanyKPI
{
    public class CompanyKPIReportVM
    {
        public int KPIMonth { get; set; }
        public int KPIYear { get; set; }
        public List<SelectListItem> DDLMonth { get; set; }
        public List<SelectListItem> DDLYear { get; set; }
    }
}

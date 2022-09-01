using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Maxco.Business.OrderPlanReports
{
    public class IndexVM
    {
        public int ReportType { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
        //public int SearchYear { get; set; }
        //public int SearchWeek { get; set; }
        public List<SelectListItem> DDLBuyer { get; set; }
        public List<SelectListItem> DDLOrder { get; set; }
        public List<SelectListItem> DDLReportType { get; set; }
        //public List<SelectListItem> DDLSearchYear { get; set; }
        //public List<SelectListItem> DDLSearchWeek{ get; set; }
    }
}

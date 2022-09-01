using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.EMS.Business.ShipmentReport
{
    public class WeeklyExportDetailsVM
    {
        public int ReportType { get; set; }
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Buyer Name")]
        public int BuyerID { get; set; }
        [Display(Name = "Order")]
        public long OrderID { get; set; }
        [Display(Name = "Ex-Factory Date")]
        public string ExFactoryDateFrom { get; set; }
        public string ExFactoryDateTo { get; set; }

        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLBuyer { get; set; }
        public List<SelectListItem> DDLReportType { get; set; }
    }
}

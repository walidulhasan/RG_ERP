using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.YarnStockReports
{
    public class YarnStockReportVM
    {
        [Display(Name ="Report Type")]
        public int ReportType { get; set; }
        [Display(Name = "Date Form")]
        public string DateForm { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        public List<SelectListItem> DDLReportType { get; set; }
    }
}

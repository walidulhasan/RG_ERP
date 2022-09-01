using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.Embro.Business.LoanMasters
{
    public class LoanListSearchVM
    {
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Bank")]
        public int BankID { get; set; }
        [Display(Name = "Loan Type")]
        public int LoanTypeID { get; set; }
        [Display(Name = "Loan Number")]
        public decimal LoanCOAID { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string ReportType { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLLoanTypeName { get; set; }
        public List<SelectListItem> DDLLoanNumber { get; set; }
        public List<SelectListItem> DDLBank { get; set; }
        public List<SelectListItem> DDLReportType { get; set; }
    }
}

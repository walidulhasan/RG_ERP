using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.ViewModel.Embro.Business.AccountsLedgers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Embro.Business.AccountsLedgers
{
    public class LedgerReportVM
    {
        [Display(Name ="Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Cost Center")]
        public int CostCenterID { get; set; }
        [Display(Name = "Activity")]
        public int ActivityID { get; set; }
        [Display(Name = "Category")]
        public int AccCategoryID { get; set; }
        [Display(Name = "Ledger Name")]
        public int AccID { get; set; }
        [Display(Name = "Fiscal Start Date")]
        public string StartDate { get; set; }
        [Display(Name = "Fiscal End Date")]
        public string EndtDate { get; set; }

        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLCostCenter { get; set; }
        public List<SelectListItem> DDLActivity { get; set; }
        public List<SelectListItem> DDLCategory { get; set; }
        public List<SelectListItem> DDLLedgerName { get; set; }
    }
}

public class LedgerReportVMValidation : AbstractValidator<LedgerReportVM>
{
    public LedgerReportVMValidation()
    {
        RuleFor(b => b.CompanyID).NotEmpty().WithMessage("Company Can't be Empty");
        RuleFor(b => b.AccCategoryID).NotEmpty().WithMessage("Category Can't be Empty");
        RuleFor(b => b.AccID).NotEmpty().WithMessage("Ledger Name Can't be Empty");
    }
}

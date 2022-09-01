using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Mappings;
using RG.Application.ViewModel.Embro.Business.LoanMasters;
using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.Embro.Business.LoanMasters
{
    public class LoanMasterCreateVM : IMapFrom<LoanMaster>
    {
        //LoanMaster
        public LoanMasterCreateVM()
        {
            LoanInstallment = new List<LoanInstallmentVM>();
        }

        public int LoanID { get; set; }
        [Display(Name = "Bank")]
        public int BankID { get; set; }
        [Display(Name = "Loan Type")]
        public int LoanTypeID { get; set; }
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        [Display(Name = "Loan Number")]
        public decimal LoanCOAID { get; set; }
        public bool IsPrincipleCOA { get; set; }
        [Display(Name = "Loan Charge")]
        public decimal? LoanChargeCOAID { get; set; }
        [Display(Name = "Loan Limit Amount")]
        public decimal? LoanLimitAmount { get; set; }
        [Display(Name = "Loan Amount")]
        public decimal? LoanAmount { get; set; }
        [Display(Name = "Interest %")]
        public decimal? InterestPercent { get; set; }
        [Display(Name = "Toatal Installment")]
        public int? TotalInstallment { get; set; }
        [Display(Name = "Installment Amount")]
        public decimal? InstallmentAmount { get; set; }
        [Display(Name = "Payment Period")]
        public int? PaymentPeriodInMonth { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public string StartDateStr { get { return StartDate.ToString("dd-MMM-yyyy"); } }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public string EndDateStr { get { return EndDate.ToString("dd-MMM-yyyy"); } }


        //LoanInstallment
        //public long LoanInstallmentID { get; set; }


        public List<SelectListItem> DDLPaymentPeriodInDaysWiseMonth { get; set; }
        public List<SelectListItem> DDLLoanTypeName { get; set; }
        public List<SelectListItem> DDLLoanNumber { get; set; }
        public List<SelectListItem> DDLBank { get; set; }
        public List<SelectListItem> DDLPaymentType { get; set; }
        public List<LoanInstallmentVM> LoanInstallment { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<LoanMasterCreateVM, LoanMaster>().ReverseMap();
        }
    }

    public class LoanInstallmentVM : IMapFrom<LoanInstallment>
    {
        public long LoanInstallmentID { get; set; }
        public int LoanID { get; set; }
        public decimal LoanCOAID { get; set; }
        public int InstallmentNo { get; set; }
        public DateTime InstallmentDate { get; set; }
        public string InstallmentDateStr { get { return InstallmentDate.ToString("dd-MMM-yyyy"); } }
        public decimal InstallmentAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<LoanInstallmentVM, LoanInstallment>().ReverseMap();
        }
    }
}
public class LoanUpdateVMValidation : AbstractValidator<LoanMasterCreateVM>
{
    public LoanUpdateVMValidation()
    {
        RuleFor(b => b.LoanTypeID).NotEmpty().WithMessage("Loan Type Can't be Empty");
        RuleFor(b => b.LoanCOAID).NotEmpty().WithMessage("Loan Number Can't be Empty");
        RuleFor(b => b.PaymentType).NotEmpty().WithMessage("Payment Type Can't be Empty");
        RuleFor(b => b.BankID).NotEmpty().WithMessage("Bank Can't be Empty");
    }
}

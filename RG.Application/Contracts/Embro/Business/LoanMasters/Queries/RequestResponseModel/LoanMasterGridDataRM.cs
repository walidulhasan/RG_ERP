using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Business.LoanMasters.Queries.RequestResponseModel
{
    public class LoanMasterGridDataRM
    {
        public int LoanID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int BankID { get; set; }
        public string BankName { get; set; }
        public int LoanTypeID { get; set; }
        public string LoanType { get; set; }
        public string PaymentType { get; set; }
        public decimal LoanCOAID { get; set; }
        public string LoanNumber { get; set; }
        public bool IsPrincipleCOA { get; set; }
        public string LoanChargeAccount{ get; set; }
        public decimal? LoanChargeCOAID { get; set; }
        public decimal? LoanLimitAmount { get; set; }
        public decimal? LoanAmount { get; set; }
        public decimal? InterestPercent { get; set; }
        public int? TotalInstallment { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public int? PaymentPeriodInMonth { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartDateStr { get { return StartDate.HasValue==true? StartDate.Value.ToString("dd-MMM-yyyy"):""; } }
        public DateTime? EndDate { get; set; }
        public string EndDateStr { get { return EndDate.HasValue==true ? EndDate.Value.ToString("dd-MMM-yyyy"):""; } }
    }
}

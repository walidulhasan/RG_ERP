using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Business.LoanMasters.Queries.RequestResponseModel
{

    public class BankLoanPositionRM
    {
        public BankLoanPositionRM()
        {
            BankLoanPositionData = new List<BankLoanPositionData>();
        }
        public string CompanyName { get; set; }
        public string CopnanyAddress { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string LoanType { get; set; }
        public string LoanAccount { get; set; }
        public string Bank { get; set; }
        public string ReportName { get; set; }
        public List<BankLoanPositionData> BankLoanPositionData { get; set; }
    }
    public class BankLoanPositionData
    {
        public int LoanID { get; set; }
        public int CompanyID { get; set; }
        public int BankId { get; set; }
        public int LoanTypeID { get; set; }
        public int LoanAcountID { get; set; }
        public string AccountName { get; set; }
        public string CompanyName { get; set; }
        public string BankName { get; set; }
        public string LoanTypeName { get; set; }
        public decimal LoanLimitAmount { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestPercent { get; set; }
        public int? TotalInstallment { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public decimal? DueInstallmentAmount { get; set; }
        public decimal? NoOfDueInstallment { get; set; }
        public int? PaymentPeriodInMonth { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartDateSTR { get { return StartDate.HasValue?StartDate.Value.ToString("dd-MMM-yyyy"):""; } }
        public DateTime? EndDate { get; set; }
        public string EndDateSTR { get { return EndDate.HasValue ? EndDate.Value.ToString("dd-MMM-yyyy") : ""; } }
        public decimal OpeningLoanAmount { get; set; }
        public decimal CurrentDisbursementAmount { get; set; }
        public decimal CurrentInterestAmount { get; set; }
        public decimal CurrentRepaymentAmount { get; set; }
        public decimal ClosingBalance { get; set; }
        public DateTime DateFrom { get; set; }
        public string DateFromSTR { get { return DateFrom.ToString("dd-MMM-yyyy"); } }
        public DateTime DateTo { get; set; }
        public string DateToSTR { get { return DateTo.ToString("dd-MMM-yyyy"); } }
        public decimal? BankCharge { get; set; }
        public decimal OpeningLoanAmountUSD { get; set; }
        public decimal CurrentDisbursementAmountUSD { get; set; }
        public decimal CurrentInterestAmountUSD { get; set; }
        public decimal CurrentRepaymentAmountUSD { get; set; }
        public decimal BankChargeUSD { get; set; }
        public decimal ClosingBalanceUSD { get; set; }
        public bool IsForeignLoan { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Embro.Business
{
    public class LoanMaster:DefaultTableProperties
    {
        public LoanMaster()
        {
            LoanInstallment = new List<LoanInstallment>();
        }
        public int LoanID { get; set; }
        public int BankID { get; set; }
        public int LoanTypeID { get; set; }
        public string PaymentType { get; set; }
        public decimal LoanCOAID { get; set; }
        public bool IsPrincipleCOA { get; set; }
        public decimal? LoanChargeCOAID { get; set; }
        public decimal? LoanLimitAmount { get; set; }
        public decimal? LoanAmount { get; set; }
        public decimal? InterestPercent { get; set; }
        public int? TotalInstallment { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public int? PaymentPeriodInMonth { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
       
        
        
        

        public virtual List<LoanInstallment> LoanInstallment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class BTB_Cash_LC_OverdueMaturityNotificationRM
    {
        /*
        Voucherid CompanyName suppliername LCALD_Description   LCNumber BankName 
            lmc_BankLCDate AuthorizeDate   BankAcceptanceDate BankMaturityDate   
            LOM_CODE AcceptanceCurrency  ValueFC ValueBDT    BRVAMOUNT ExceedDays
            Comments
            */
        public long? Voucherid { get; set; }
        public string CompanyName { get; set; }
        public string CompanyShortName { get; set; }
        public string Supplier { get; set; }
        public string LCType { get; set; }
        public string LCNumber { get; set; }
        public string BankName { get; set; }
        public string LCDate { get; set; }
        public string AcceptanceDate { get; set; }
        public string BankDate { get; set; }
        public string MaturityDate { get; set; }
        public string MasterLC { get; set; }
        public string Currency { get; set; }
        public decimal ValueFC { get; set; }
        public decimal ValueBDT { get; set; }
        public int ExceedDays { get; set; }
        public string Remarks { get; set; }

    }
}

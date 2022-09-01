using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class FDBP_FDBCEntryNotificationRM
    {
        public string CompanyName { get; set; }
        public string BankName { get; set; }
        public string DocumentNumber { get; set; }
        public string CreationDate { get; set; }
        public string ApprovalDate { get; set; }
        public decimal DocumentValue { get; set; }
        public int ExceedDays { get; set; }
        public string Remarks { get; set; }
        
    }
}

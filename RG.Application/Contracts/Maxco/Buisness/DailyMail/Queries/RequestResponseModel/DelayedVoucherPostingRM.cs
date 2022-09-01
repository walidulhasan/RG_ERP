using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class DelayedVoucherPostingRM
    {
        public string Companyname { get; set; }
        public string VoucherNumber { get; set; }
        public string Reference { get; set; }
        public string CreationDate { get; set; }
        public string VoucherDate { get; set; }
        public string ApprovedDate { get; set; }
        public string PreparedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string Description { get; set; }
        public int DaysDifference { get; set; }
        public int ApprovedInDays { get; set; }        
        public string Billno { get; set; }
    }
}

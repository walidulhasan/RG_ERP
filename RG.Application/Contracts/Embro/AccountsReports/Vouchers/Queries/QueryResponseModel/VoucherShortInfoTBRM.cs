using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel
{
    public class VoucherShortInfoTBRM
    {
        public decimal VoucherId { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime VDate { get; set; }
        public string VDateMsg { get { return VDate.ToString("dd-MMM-yyyy"); } }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public decimal Debit { get { return Amount > 0 ? Amount / (NeedConversion == true ? CRate : 1) : 0; } }
        public decimal Credit { get { return Amount < 0 ? Math.Abs(Amount / (NeedConversion == true ? CRate : 1)) : 0; } }
        public string VoucherDescription { get; set; }
        public long Costcenter { get; set; }
        public string CostcenterName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public long Activity { get; set; }
        public string ActivityName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int BusinessId { get; set; }
        public string Business { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public decimal CRate { get; set; }
        public bool NeedConversion { get; set; } = false;
    }
}

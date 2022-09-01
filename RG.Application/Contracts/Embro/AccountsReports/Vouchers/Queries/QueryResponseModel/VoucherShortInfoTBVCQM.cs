using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel
{
    public class VoucherShortInfoTBVCQM
    {
        public int AccountId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool NeedConversion { get; set; } = false;
    }
}

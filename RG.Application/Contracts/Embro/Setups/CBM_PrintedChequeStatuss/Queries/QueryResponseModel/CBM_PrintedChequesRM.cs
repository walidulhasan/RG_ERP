using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.CBM_PrintedChequeStatuss.Queries.QueryResponseModel
{
    public class CBM_PrintedChequesRM
    {
        public long ChqID { get; set; }
        public string SupplierTree { get; set; }
        public string Supplier { get; set; }
        public string ChqNumber { get; set; }
        public string ChqDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string StatusDate { get; set; }
        public string ContactPerson { get; set; }
        public string Identity { get; set; }
        public string POActivity { get; set; }
        public string VoucherDescription { get; set; }

    }
}

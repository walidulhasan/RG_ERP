using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AOP.Business.Tbl_Issuance_Masters.Queries.RequestResponseModel
{
    public class IssuancePaymentInfoSPRM
    {
        public string OrderType { get; set; }
        public long OrderID { get; set; }
        public long PaymentModeID { get; set; }
        public long PaymentTermID { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTermFull { get; set; }
        public string PaymentTerm { get; set; }
        public int LC_OK { get; set; }
        public int IsCalculationWithGray { get; set; }
    }
}

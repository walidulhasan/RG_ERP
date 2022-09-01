using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AOP.Business.tbl_challan_master.Queries.RequestResponseModel
{
    public class ChallanCustomerInfoRM
    {
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

    }
}

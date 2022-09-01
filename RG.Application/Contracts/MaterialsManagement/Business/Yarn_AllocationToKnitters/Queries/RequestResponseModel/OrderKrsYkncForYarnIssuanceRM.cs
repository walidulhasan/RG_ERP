using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel
{
    public class OrderKrsYkncForYarnIssuanceRM
    {
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public int KRSID { get; set; }
        public string KRSName { get; set; }
        public long YKNCID { get; set; }
        public string YKNCName { get; set; }
    }
}

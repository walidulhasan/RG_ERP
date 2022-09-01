using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel
{
    public class YKNCDetailInfoRM
    {
        public long YKNCID { get; set; }
        public int MRPItemCode { get; set; }
        public long AttributeInstanceID { get; set; }
        public string YarnCount { get; set; }
        public string YarnComposition { get; set; }
        public string YarnQuality { get; set; }
        public double Utilization { get; set; }
        public decimal YarnTotalWithWastageQty { get; set; }
        public double AllocatedQty { get; set; }
        public double IssuedQty { get; set; }
        public double ReturnQty { get; set; }
        public double YarnTotalQty { get; set; }
        public double MovingAverage { get; set; }
        

    }
}

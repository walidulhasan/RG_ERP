using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel
{
    public class YarnLotForIssuanceRM
    {
        public YarnLotForIssuanceRM()
        {
            YarnAttributeInfo = new List<YarnAttributeInfoRM>();
        }
        public YKNCMasterDetailInfoRM YKNCMasterDetailInfo { get; set; }
        public List<YarnAttributeInfoRM> YarnAttributeInfo { get; set; }
        //public List<YKNCLotMasterDetailInfoRM> YKNCLotMasterDetailInfo { get; set; }
    }
}

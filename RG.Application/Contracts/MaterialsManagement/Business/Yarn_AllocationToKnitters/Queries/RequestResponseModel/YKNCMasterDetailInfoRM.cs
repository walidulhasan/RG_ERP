using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel
{
    public class YKNCMasterDetailInfoRM
    {
        public YKNCMasterInfoRM YKNCMasterInfo { get; set; }
        public List<YKNCDetailInfoRM> YKNCDetailInfo { get; set; }
    }
}

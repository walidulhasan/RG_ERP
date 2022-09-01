using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel
{
    public class YKNCLotMasterDetailInfoRM: YKNCLotMasterInfoRM
    {
        //public YKNCLotMasterInfoRM YKNCLotMasterInfo { get; set; }
        public List<YKNCLotDetailInfoRM> YKNCLotDetailInfo { get; set; }
    }
}

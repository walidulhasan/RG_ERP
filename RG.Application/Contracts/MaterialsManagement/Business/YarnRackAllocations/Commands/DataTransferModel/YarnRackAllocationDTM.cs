using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.YarnRackAllocations.Commands.DataTransferModel
{
    public class YarnRackAllocationDTM:IMapFrom<YarnRackAllocation>
    {
        public long RackAllocationID { get; set; }
        public long YarnStockTransactionID { get; set; }
        public int SubRackID { get; set; }
        public decimal AllocatedQuantity { get; set; }
        public decimal? BalanceQuantity { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<YarnRackAllocationDTM, YarnRackAllocation>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel
{
    public class YKNCLotDetailInfoRM
    {
        public long RackAllocationID { get; set; }
        public string LotNo { get; set; }
        public long CompanyID { get; set; }
        public int BusinessID { get; set; }
        public long AttributeInstanceID { get; set; }
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }
        public int BuildingFloorID { get; set; }
        public string FloorName { get; set; }
        public int RackID { get; set; }
        public string RackName { get; set; }
        public int SubRackID { get; set; }
        public string SubRackName { get; set; }
        public decimal BalanceQuantity { get; set; }
       
    }
}

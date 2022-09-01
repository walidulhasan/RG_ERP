using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.RequestResponseModel
{
    public class YarnSubRackAllocationBalanceRM
    {
        public string BuildingName { get; set; }
        public string FloorName { get; set; }
        public int RackID { get; set; }
        public string RackName { get; set; }
        public string RackShortName { get; set; }
        public string SubRackName { get; set; }
        public string SubRackShortName { get; set; }
        public string LotNo { get; set; }
        public int RackSerial { get; set; }
        public int SubRackSerial { get; set; }
        public decimal BalanceQuantity { get; set; }

    }
}

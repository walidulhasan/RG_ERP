using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class YarnRackAllocation:DefaultTableProperties
    {
        public long RackAllocationID { get; set; }
        public long YarnStockTransactionID { get; set; }
        public int SubRackID { get; set; }
        public decimal AllocatedQuantity { get; set; }
        public decimal? BalanceQuantity { get; set; }
    }
}

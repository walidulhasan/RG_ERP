using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class AllocatedYarnIssueFromRack:DefaultTableProperties
    {
        public long IssuanceID { get; set; }
        public long YarnStockTransactionID { get; set; }
        public int SubRackID { get; set; }
        public decimal IssuedQuantity { get; set; }    
    }
}

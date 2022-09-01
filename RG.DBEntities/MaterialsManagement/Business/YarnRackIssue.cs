using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class YarnRackIssue:DefaultTableProperties
    {
        public long RackIssueID { get; set; }
        public long YarnStockTransactionID { get; set; }
        public long RackAllocationID { get; set; }
        public decimal IssueQuantity { get; set; }

    }
}

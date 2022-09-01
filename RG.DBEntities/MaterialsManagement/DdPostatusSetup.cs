using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdPostatusSetup
    {
        public DdPostatusSetup()
        {
            DdPurchaseOrder = new HashSet<DdPurchaseOrder>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string UsedFor { get; set; }

        public virtual ICollection<DdPurchaseOrder> DdPurchaseOrder { get; set; }
    }
}

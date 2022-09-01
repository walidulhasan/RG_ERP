using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmReturnToSupplierMaster1
    {
        public long Rsmid { get; set; }
        public DateTime CreationDate { get; set; }
        public long Poid { get; set; }
        public long SupplierId { get; set; }
        public int? UserId { get; set; }
        public int? Status { get; set; }
    }
}

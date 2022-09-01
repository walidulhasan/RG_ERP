using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmReturnToSupplierMaster
    {
        public long Rsmid { get; set; }
        public string Rsmno { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UserId { get; set; }
    }
}

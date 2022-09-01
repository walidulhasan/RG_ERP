using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdblockedSupplier
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int BlockReasonId { get; set; }
        public string Remarks { get; set; }
        public short Status { get; set; }
        public DateTime? BlockDate { get; set; }
        public int? UnblockReasonId { get; set; }

        public virtual DDReasons_Setup BlockReason { get; set; }
        public virtual Ddsupplier Supplier { get; set; }
    }
}

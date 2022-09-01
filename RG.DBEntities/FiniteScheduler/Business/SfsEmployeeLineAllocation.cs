using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsEmployeeLineAllocation
    {
        public SfsEmployeeLineAllocation()
        {
            SfsEmployeeLineAllocationDetail = new HashSet<SfsEmployeeLineAllocationDetail>();
        }

        public long Id { get; set; }
        public long StyleId { get; set; }
        public long Prsid { get; set; }
        public DateTime AllocationDate { get; set; }
        public int VersionNo { get; set; }
        public long? GeversionNo { get; set; }
        public int? ChainOperationSetupId { get; set; }
        public bool? Ge2 { get; set; }
        public int? JobId { get; set; }

        public virtual ICollection<SfsEmployeeLineAllocationDetail> SfsEmployeeLineAllocationDetail { get; set; }
    }
}

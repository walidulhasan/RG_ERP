using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsEmpOfflineAllocationMaster
    {
        public SfsEmpOfflineAllocationMaster()
        {
            SfsEmpOfflineDetail = new HashSet<SfsEmpOfflineDetail>();
        }

        public int Id { get; set; }
        public int StyleId { get; set; }
        public DateTime CreateDate { get; set; }
        public int VersionNo { get; set; }
        public int Prsid { get; set; }
        public int? ChainOperationSetupId { get; set; }
        public int? GeversionNo { get; set; }
        public int? EmployeeLineAllocation { get; set; }

        public virtual ICollection<SfsEmpOfflineDetail> SfsEmpOfflineDetail { get; set; }
    }
}

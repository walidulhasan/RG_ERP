using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsPickListMaster
    {
        public SfsPickListMaster()
        {
            SfsPickListDetail = new HashSet<SfsPickListDetail>();
        }

        public long PicklistId { get; set; }
        public long JobId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public DateTime? AckDate { get; set; }
        public int StatusId { get; set; }

        public virtual SfsJob Job { get; set; }
        public virtual SfsPickListStatus Status { get; set; }
        public virtual ICollection<SfsPickListDetail> SfsPickListDetail { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsPickListStatus
    {
        public SfsPickListStatus()
        {
            SfsPickListMaster = new HashSet<SfsPickListMaster>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SfsPickListMaster> SfsPickListMaster { get; set; }
    }
}

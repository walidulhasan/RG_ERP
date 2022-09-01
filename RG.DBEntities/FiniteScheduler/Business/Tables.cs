using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class Tables
    {
        public Tables()
        {
            TableLoad = new HashSet<TableLoad>();
        }

        public int FamId { get; set; }
        public int? FamparentId { get; set; }
        public string TableNo { get; set; }

        public virtual ICollection<TableLoad> TableLoad { get; set; }
    }
}

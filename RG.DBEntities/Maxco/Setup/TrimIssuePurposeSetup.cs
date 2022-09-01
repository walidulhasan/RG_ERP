using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TrimIssuePurposeSetup
    {
        public TrimIssuePurposeSetup()
        {
            TrimIssueMaster = new HashSet<TrimIssueMaster>();
        }
        public int Id { get; set; }
        public int PurposeId { get; set; }
        public string PurposeDesc { get; set; }

        public virtual ICollection<TrimIssueMaster> TrimIssueMaster { get; set; }
    }
}

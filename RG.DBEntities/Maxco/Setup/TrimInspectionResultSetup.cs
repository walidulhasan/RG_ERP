using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TrimInspectionResultSetup
    {
        public TrimInspectionResultSetup()
        {
            TrimInspectionDetail = new HashSet<TrimInspectionDetail>();
        }
        public int Id { get; set; }
        public int TrimInspectionResultId { get; set; }
        public string InspectionResultDesc { get; set; }

        public virtual ICollection<TrimInspectionDetail> TrimInspectionDetail { get; set; }
    }
}

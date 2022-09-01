using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class EmbroideryInspectionMaster
    {
        public EmbroideryInspectionMaster()
        {
            EmbroideryInspectionDetails = new HashSet<EmbroideryInspectionDetails>();
        }

        public int EmbroideryInspectionMasterId { get; set; }
        public int EmbroiderySpecificationId { get; set; }
        public int UserId { get; set; }
        public DateTime Dated { get; set; }

        public virtual ICollection<EmbroideryInspectionDetails> EmbroideryInspectionDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class Cadcamjob
    {
        public Cadcamjob()
        {
            CadcambodyPart = new HashSet<CadcambodyPart>();
        }

        public int CadcamjobId { get; set; }
        public string CadcamjobNo { get; set; }
        public long StyleId { get; set; }
        public long AssignedStyleId { get; set; }
        public long AttributeInstanceId { get; set; }
        public int MarkerReceivedStatus { get; set; }

        public virtual ICollection<CadcambodyPart> CadcambodyPart { get; set; }
    }
}

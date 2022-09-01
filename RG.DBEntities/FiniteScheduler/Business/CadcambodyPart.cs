using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CadcambodyPart
    {
        public CadcambodyPart()
        {
            CadcampatternPiece = new HashSet<CadcampatternPiece>();
        }

        public int BodyPartId { get; set; }
        public int CadcamjobId { get; set; }
        public int QrmfabricTrimId { get; set; }

        public virtual Cadcamjob Cadcamjob { get; set; }
        public virtual ICollection<CadcampatternPiece> CadcampatternPiece { get; set; }
    }
}

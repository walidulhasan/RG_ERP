using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class CadcamDispatch
    {
        public CadcamDispatch()
        {
            CadcamDispatchColorSets = new HashSet<CadcamDispatchColorSets>();
            CadcamDispatchDetails = new HashSet<CadcamDispatchDetails>();
        }

        public int Id { get; set; }
        public long StyleId { get; set; }
        public int DispatchNo { get; set; }
        public int VersionNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? IsActive { get; set; }
        public decimal? ConsumptionPerPiece { get; set; }

        public virtual ICollection<CadcamDispatchColorSets> CadcamDispatchColorSets { get; set; }
        public virtual ICollection<CadcamDispatchDetails> CadcamDispatchDetails { get; set; }
    }
}

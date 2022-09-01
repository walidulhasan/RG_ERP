using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsLotVariationQuantities
    {
        public FsLotVariationQuantities()
        {
            FsVariationStyleFabrics = new HashSet<FsVariationStyleFabrics>();
        }

        public int Id { get; set; }
        public int IsCircular { get; set; }
        public int Index { get; set; }
        public int? ProcessRate { get; set; }
        public int ReceivedQuantityKgs { get; set; }
        public int RollsPieces { get; set; }
        public int LotVariationId { get; set; }
        public int? ReceivedGsm { get; set; }
        public int? ReceivedWidth { get; set; }
        public long? Balance { get; set; }

        public virtual FsReceivingLotVariations LotVariation { get; set; }
        public virtual ICollection<FsVariationStyleFabrics> FsVariationStyleFabrics { get; set; }
    }
}

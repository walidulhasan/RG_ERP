using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class TwillTapeUse
    {
        public int Id { get; set; }
        public long ObjectId { get; set; }
        public int GarmentSizeRangeId { get; set; }
        public double UsePerPiece { get; set; }

        public virtual TwillTapeSpecification Object { get; set; }
    }
}

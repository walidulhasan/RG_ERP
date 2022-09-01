using RG.DBEntities.Maxco.Trims;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco
{
    public partial class DrawstringUse
    {
        public int ID { get; set; }
        [ForeignKey("DrawstringSpecification")]
        public int ObjectID { get; set; }
        public int GarmentSizeRangeID { get; set; }
        public double UsePerPiece { get; set; }

        public virtual DrawstringSpecification Object { get; set; }
    }
}

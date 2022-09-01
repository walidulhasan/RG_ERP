using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ElasticUse
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public int GarmentSizeRangeId { get; set; }
        public double UsePerPiece { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeId { get; set; }

        public virtual ElasticSpecification Object { get; set; }
    }
}

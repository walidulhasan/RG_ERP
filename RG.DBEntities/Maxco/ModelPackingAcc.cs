using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelPackingAcc
    {
        public int Id { get; set; }
        public int PackingTypeId { get; set; }
        public double? UnitCost { get; set; }
        public int? StyleId { get; set; }
        public int? CollectionId { get; set; }
        public int? VersionId { get; set; }

        public virtual ModelCosting ModelCosting { get; set; }
    }
}

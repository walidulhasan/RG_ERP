using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GarmentAssortmentOrder
    {
        public int Id { get; set; }
        public int OrderStyleId { get; set; }
        public int? FabricId { get; set; }
        public int SizeSetId { get; set; }
        public int ColorSetId { get; set; }
        public bool? IsMain { get; set; }
        public int NumberOfGarments { get; set; }
        public int? SuperBomid { get; set; }

        public virtual OrderSelectedStyle OrderStyle { get; set; }
    }
}

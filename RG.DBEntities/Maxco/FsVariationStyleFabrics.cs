using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsVariationStyleFabrics
    {
        public int Id { get; set; }
        public int VariationQuantitiesId { get; set; }
        public int StyleId { get; set; }
        public int? FabricId { get; set; }
        public int ShellColorSetId { get; set; }
        public int? ColorSetId { get; set; }

        public virtual FsLotVariationQuantities VariationQuantities { get; set; }
    }
}

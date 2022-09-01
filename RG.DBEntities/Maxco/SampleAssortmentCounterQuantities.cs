using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class SampleAssortmentCounterQuantities
    {
        public int Id { get; set; }
        public int CounterId { get; set; }
        public long FabricSpecificationColorId { get; set; }
        public int AssortmentId { get; set; }
        public int? Quantity { get; set; }

        public virtual SampleAssortment Assortment { get; set; }
        public virtual SampleAssortmentCounterSetup Counter { get; set; }
    }
}

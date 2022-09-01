using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GarmentAssortment
    {
        public int Id { get; set; }
        public int SampleAssortmentId { get; set; }
        public long FabricSpecificationColorId { get; set; }
        public long SelectedSizeRangeId { get; set; }
        public int Quantity { get; set; }
        public bool? IsCounter { get; set; }

        public virtual SampleAssortment SampleAssortment { get; set; }
        public virtual SelectedGarmentSizeRange SelectedSizeRange { get; set; }
    }
}

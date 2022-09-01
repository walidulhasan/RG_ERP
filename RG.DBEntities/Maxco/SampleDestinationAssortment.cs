using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SampleDestinationAssortment
    {
        public int Id { get; set; }
        public int SampleDestinationId { get; set; }
        public int FabricSpecificationColorId { get; set; }
        public int SelectedSizeRangeId { get; set; }
        public int Quantity { get; set; }

        public virtual SampleDestination SampleDestination { get; set; }
    }
}

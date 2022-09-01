using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FinishedFabricWashing
    {
        public int Id { get; set; }
        public int FinishedFabricId { get; set; }
        public int WashingTypeId { get; set; }

        public virtual SampleMirfinishedFabric FinishedFabric { get; set; }
    }
}

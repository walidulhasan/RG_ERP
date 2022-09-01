using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class EmbroAppliqueThreads
    {
        public long Id { get; set; }
        public long? EmbroPrintFabricSpecificationId { get; set; }
        public long? ThreadId { get; set; }
        public byte? LayerNo { get; set; }

        public virtual EmbroPrintFabricSpecification EmbroPrintFabricSpecification { get; set; }
        public virtual EmbroLayers Thread { get; set; }
    }
}

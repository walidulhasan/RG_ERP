using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricWashingFinishingSpecification
    {
        public int ID { get; set; }
        public long FabricSpecificationID { get; set; }
        public long CodeID { get; set; }
        public int ProcessTypeID { get; set; }
        public string Location { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
    }
}

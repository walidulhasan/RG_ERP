using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricFeederStripeSpecification
    {
        public int ID { get; set; }
        public long YarnSpecificationID { get; set; }
        public int StripeNo { get; set; }

      //  public virtual FabricYarnSpecification YarnSpecification { get; set; }
    }
}

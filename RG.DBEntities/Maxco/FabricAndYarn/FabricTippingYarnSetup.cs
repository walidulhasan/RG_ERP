using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTippingYarnSetup
    {
        public int Id { get; set; }
        public long FabricTippingSpecificationId { get; set; }
        public long YarnSpecificationId { get; set; }
        public bool IsColorYarn { get; set; }
        public long ColorSetId { get; set; }
    }
}

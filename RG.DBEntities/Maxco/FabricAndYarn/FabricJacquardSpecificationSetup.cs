using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricJacquardSpecificationSetup
    {
        public long Id { get; set; }
        public long BaseYarnId { get; set; }
        public long DesignYarnId { get; set; }
    }
}

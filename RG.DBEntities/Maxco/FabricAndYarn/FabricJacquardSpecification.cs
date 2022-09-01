using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricJacquardSpecification
    {
        public int Id { get; set; }
        public long BaseYarnId { get; set; }
        public long DesignYarnId { get; set; }

        public virtual FabricYarnSpecification BaseYarn { get; set; }
        public virtual FabricYarnSpecification DesignYarn { get; set; }
    }
}

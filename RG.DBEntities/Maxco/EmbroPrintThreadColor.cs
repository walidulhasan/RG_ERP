using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class EmbroPrintThreadColor
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public long ColorSetId { get; set; }
        public string TrimColor { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
    }
}

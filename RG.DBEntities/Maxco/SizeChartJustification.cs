using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco
{
    public partial class SizeChartJustification
    {
        public int Id { get; set; }
        public int JustificationId { get; set; }
        public int VersionId { get; set; }

        public virtual SizeChartJustificationSetup Justification { get; set; }
    }
}

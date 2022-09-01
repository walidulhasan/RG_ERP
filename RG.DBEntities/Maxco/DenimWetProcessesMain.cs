using System;
using System.Collections.Generic;

using RG.DBEntities.Maxco.FabricAndYarn;
namespace RG.DBEntities.Maxco
{
    public partial class DenimWetProcessesMain
    {
        public int Id { get; set; }
        public int SelectedElementId { get; set; }
        public string WashingCode { get; set; }
        public long ColorSetId { get; set; }
        public string SwatchNo { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
    }
}

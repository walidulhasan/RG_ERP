using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Business;

namespace RG.DBEntities.Maxco
{
    public partial class PlacementPointSequence
    {
        public int Id { get; set; }
        public short PlacementPointId { get; set; }
        public short PlacementSequence { get; set; }
        public int SelectedElementId { get; set; }
        public bool? IsFabricUsage { get; set; }
        public int? VersionId { get; set; }

        public virtual PlacementPointSetup PlacementPoint { get; set; }
        public virtual SelectedElement SelectedElement { get; set; }
    }
}

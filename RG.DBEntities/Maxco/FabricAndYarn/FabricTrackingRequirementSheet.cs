using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTrackingRequirementSheet
    {
        public int Id { get; set; }
        public int FabricTrackingId { get; set; }
        public int RequirementSheetId { get; set; }
    }
}

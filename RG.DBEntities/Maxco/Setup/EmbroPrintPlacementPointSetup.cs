using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class EmbroPrintPlacementPointSetup
    {
        public EmbroPrintPlacementPointSetup()
        {
            EmbroPlacementInstruction = new HashSet<EmbroPlacementInstruction>();
        }

        public short Id { get; set; }
        public string Description { get; set; }
        public short TrimId { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<EmbroPlacementInstruction> EmbroPlacementInstruction { get; set; }
    }
}

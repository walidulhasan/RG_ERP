using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ElementPlacementInstructionsSetup
    {
        public ElementPlacementInstructionsSetup()
        {
            PrintingPlacementInstruction = new HashSet<PrintingPlacementInstruction>();
        }

        public short Id { get; set; }
        public string Description { get; set; }
        public int OrderStyleElementId { get; set; }

        public virtual ICollection<PrintingPlacementInstruction> PrintingPlacementInstruction { get; set; }
    }
}

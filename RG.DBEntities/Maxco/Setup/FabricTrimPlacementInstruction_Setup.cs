using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class FabricTrimPlacementInstruction_Setup
    {
        public FabricTrimPlacementInstruction_Setup()
        {
            FabricPlacementInstructionSelected = new HashSet<FabricPlacementInstructionSelected>();
        }

        public int ID { get; set; }
        public int FabricTrimID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricPlacementInstructionSelected> FabricPlacementInstructionSelected { get; set; }
    }
}

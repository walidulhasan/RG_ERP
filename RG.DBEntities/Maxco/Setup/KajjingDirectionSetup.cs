using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class KajjingDirection_Setup
    {
        public KajjingDirection_Setup()
        {
            ThreadPlacementInstruction = new HashSet<ThreadPlacementInstruction>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ThreadPlacementInstruction> ThreadPlacementInstruction { get; set; }
    }
}

using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class WovenFabricFinishing
    {
        public int Id { get; set; }
        public int FinishingId { get; set; }
        public int FabricSpecificationId { get; set; }

        public virtual WovenFinishingSetup Finishing { get; set; }
    }
}

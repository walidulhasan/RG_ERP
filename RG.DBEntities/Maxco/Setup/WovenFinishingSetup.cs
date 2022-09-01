using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class WovenFinishingSetup
    {
        public WovenFinishingSetup()
        {
            WovenFabricFinishing = new HashSet<WovenFabricFinishing>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WovenFabricFinishing> WovenFabricFinishing { get; set; }
    }
}

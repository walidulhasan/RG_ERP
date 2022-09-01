using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricFinishingSetup
    {
        public FabricFinishingSetup()
        {
            FabricFinishBusinessRuleSetup = new HashSet<FabricFinishBusinessRuleSetup>();
            FabricFinishingPropertiesSetup = new HashSet<FabricFinishingPropertiesSetup>();
            FabricSpecificationFinishing = new HashSet<FabricSpecificationFinishing>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricFinishBusinessRuleSetup> FabricFinishBusinessRuleSetup { get; set; }
        public virtual ICollection<FabricFinishingPropertiesSetup> FabricFinishingPropertiesSetup { get; set; }
        public virtual ICollection<FabricSpecificationFinishing> FabricSpecificationFinishing { get; set; }
    }
}

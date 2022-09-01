using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricWashingPropertiesSetup
    {
        public FabricWashingPropertiesSetup()
        {
            FabricSpecificationWashing = new HashSet<FabricSpecificationWashing>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricSpecificationWashing> FabricSpecificationWashing { get; set; }
    }
}

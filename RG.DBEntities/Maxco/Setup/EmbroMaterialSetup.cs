using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class EmbroMaterialSetup
    {
        public EmbroMaterialSetup()
        {
            EmbroLayers = new HashSet<EmbroLayers>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EmbroLayers> EmbroLayers { get; set; }
    }
}

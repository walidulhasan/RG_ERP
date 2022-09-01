using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class FlockMaterialSetup
    {
        public FlockMaterialSetup()
        {
            PrintingLayers = new HashSet<PrintingLayers>();
            PrintingSpecification = new HashSet<PrintingSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PrintingLayers> PrintingLayers { get; set; }
        public virtual ICollection<PrintingSpecification> PrintingSpecification { get; set; }
    }
}

using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PrintMaterialSizeSetup
    {
        public PrintMaterialSizeSetup()
        {
            PrintingLayers = new HashSet<PrintingLayers>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PrintingLayers> PrintingLayers { get; set; }
    }
}

using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PrintColorType_Setup
    {
        public PrintColorType_Setup()
        {
            PrintingLayers = new HashSet<PrintingLayers>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PrintingLayers> PrintingLayers { get; set; }
    }
}

using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PrintingType_Setup
    {
        public PrintingType_Setup()
        {
            PrintEmbroImageSetup = new HashSet<PrintEmbroImage_Setup>();
            PrintingLayers = new HashSet<PrintingLayers>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public bool? IsDisplay { get; set; }

        public virtual ICollection<PrintEmbroImage_Setup> PrintEmbroImageSetup { get; set; }
       // public virtual ICollection<PrintEmbroImage_Setup> PrintEmbroImageSetup { get; set; }
        public virtual ICollection<PrintingLayers> PrintingLayers { get; set; }
    }
}

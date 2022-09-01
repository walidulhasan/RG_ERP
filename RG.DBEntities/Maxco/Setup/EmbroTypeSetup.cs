using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class EmbroTypeSetup
    {
        public EmbroTypeSetup()
        {
            EmbroLayers = new HashSet<EmbroLayers>();
            PrintEmbroImageSetup = new HashSet<PrintEmbroImage_Setup>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }
        public double? MachineSpeed { get; set; }
        public double? CostPerStitches { get; set; }

        public virtual ICollection<EmbroLayers> EmbroLayers { get; set; }
        public virtual ICollection<PrintEmbroImage_Setup> PrintEmbroImageSetup { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class WetProcessStagesSetup
    {
        public WetProcessStagesSetup()
        {
            DenimSelectedWetProcesses = new HashSet<DenimSelectedWetProcesses>();
            WovenSelectedWetProcesses = new HashSet<WovenSelectedWetProcesses>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DenimSelectedWetProcesses> DenimSelectedWetProcesses { get; set; }
        public virtual ICollection<WovenSelectedWetProcesses> WovenSelectedWetProcesses { get; set; }
    }
}

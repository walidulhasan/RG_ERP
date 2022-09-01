using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class MachineDiameterSetup
    {
        public MachineDiameterSetup()
        {
            KnittingExperiment = new HashSet<KnittingExperiment>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<KnittingExperiment> KnittingExperiment { get; set; }
    }
}

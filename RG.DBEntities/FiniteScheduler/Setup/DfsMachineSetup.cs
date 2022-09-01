using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class DfsMachineSetup
    {
        public long Id { get; set; }
        public string MachineName { get; set; }
        public double? Smv { get; set; }
    }
}

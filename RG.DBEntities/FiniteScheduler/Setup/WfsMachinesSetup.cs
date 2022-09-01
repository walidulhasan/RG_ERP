using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WfsMachinesSetup
    {
        public int Id { get; set; }
        public int FamMachineTypeId { get; set; }
        public int MachineId { get; set; }
        public string Name { get; set; }
        public double? SetupTime { get; set; }
    }
}

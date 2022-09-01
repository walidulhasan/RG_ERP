using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GwmachineTypesInstances
    {
        public long Id { get; set; }
        public int FamMachineTypeId { get; set; }
        public long MachineId { get; set; }
        public string Name { get; set; }
        public int SetupTime { get; set; }
    }
}

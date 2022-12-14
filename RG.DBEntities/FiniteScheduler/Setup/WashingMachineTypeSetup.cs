using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingMachineTypeSetup
    {
        public long MachineTypeId { get; set; }
        public string MachineTypeName { get; set; }
        public int? UserId { get; set; }
        public DateTime Date { get; set; }
        public bool Deleted { get; set; }
    }
}

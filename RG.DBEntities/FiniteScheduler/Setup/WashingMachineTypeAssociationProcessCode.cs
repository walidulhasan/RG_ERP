using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingMachineTypeAssociationProcessCode
    {
        public long Id { get; set; }
        public long MachineTypeId { get; set; }
        public long ProcessCodeId { get; set; }
    }
}

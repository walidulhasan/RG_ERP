using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsLotMachineRouting
    {
        public long Id { get; set; }
        public long? MachineId { get; set; }
        public long? LotId { get; set; }
    }
}

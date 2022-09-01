using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ChainMachineFlaggedHistory
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

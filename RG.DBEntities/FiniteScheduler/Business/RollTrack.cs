using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class RollTrack
    {
        public long RollId { get; set; }
        public string RollCode { get; set; }
        public long YarnKnittingContractId { get; set; }
        public int MachineNo { get; set; }
        public int? Status { get; set; }
    }
}

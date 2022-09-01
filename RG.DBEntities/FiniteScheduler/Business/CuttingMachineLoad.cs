using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CuttingMachineLoad
    {
        public long CuttingMachineLoadId { get; set; }
        public int FamId { get; set; }
        public int MinuteId { get; set; }
        public long WcdayId { get; set; }
        public long JobTicketId { get; set; }
        public int Deleted { get; set; }

        public virtual CuttingMachineInstance Fam { get; set; }
        public virtual MinuteTime Minute { get; set; }
    }
}

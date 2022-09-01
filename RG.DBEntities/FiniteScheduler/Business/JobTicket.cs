using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class JobTicket
    {
        public int JobTicketId { get; set; }
        public long JobTicketNo { get; set; }
        public int CadcamjobId { get; set; }
        public int Status { get; set; }
        public long StyleId { get; set; }
        public long CuttingMachineId { get; set; }
        public long TableId { get; set; }
        public int StartMinuteId { get; set; }
        public int EndMinuteId { get; set; }
        public long WcdayId { get; set; }
        public long SpreadingMachineId { get; set; }
        public long RangeId { get; set; }
        public long? FabricDetailId { get; set; }
        public int? MrpitemCode { get; set; }
    }
}

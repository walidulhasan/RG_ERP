using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class ReceivingMaster
    {
        public int ReceivingMasterId { get; set; }
        public string ReceivingChallanNo { get; set; }
        public int UserId { get; set; }
        public DateTime Dated { get; set; }
        public int ReceivedFrom { get; set; }
        public int ReceivedBy { get; set; }
        public int JobTicketId { get; set; }
        public long IssuanceMasterId { get; set; }
        public string Comments { get; set; }
    }
}

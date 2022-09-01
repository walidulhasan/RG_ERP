using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class KnittingPickListDeleteLog
    {
        public long? PickListId { get; set; }
        public long? YarnKnittingContractId { get; set; }
        public long? JobId { get; set; }
        public string ReceivingPersonName { get; set; }
        public string PickListNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Acknowledge { get; set; }
        public int? YarnIssuanceStatus { get; set; }
        public DateTime? YarnReceivingDate { get; set; }
        public long? PickListDetailId { get; set; }
        public long? AttributeInstanceId { get; set; }
        public double? Quantity { get; set; }
        public int? UnitId { get; set; }
        public string BatchDescription { get; set; }
        public string Comments { get; set; }
        public short? UserId { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class KnittingSubPickListDeleteLog
    {
        public long? SubPickListId { get; set; }
        public long? MasterPickListId { get; set; }
        public string ReceivingPersonName { get; set; }
        public string SubPickListNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Acknowledge { get; set; }
        public int? YarnIssuanceStatus { get; set; }
        public DateTime? YarnReceivingDate { get; set; }
        public long? SubPickListDetailId { get; set; }
        public long? AttributeInstanceId { get; set; }
        public double? Quantity { get; set; }
        public int? UnitId { get; set; }
        public string BatchDescription { get; set; }
        public double? ReceivingQuantity { get; set; }
        public string Comments { get; set; }
        public short? UserId { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FinishingConfirmation
    {
        public long AssignedStyleId { get; set; }
        public string AssignedStyleNo { get; set; }
        public long AssignedOrderId { get; set; }
        public int StyleId { get; set; }
        public string AssignedOrderNo { get; set; }
        public int ConfirmationId { get; set; }
        public long AttributeInstanceId { get; set; }
        public int? SizeId { get; set; }
        public int? ColorId { get; set; }
        public double RequiredQuantity { get; set; }
        public double ConfirmedQuantity { get; set; }
        public string PantoneNo { get; set; }
        public int? IssuanceMasterId { get; set; }
        public string ChallanNo { get; set; }
        public long AssOrdId { get; set; }
        public int ConId { get; set; }
        public double? QtyIssued { get; set; }
    }
}

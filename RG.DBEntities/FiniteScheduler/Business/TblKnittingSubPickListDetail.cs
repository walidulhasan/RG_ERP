using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingSubPickListDetail
    {
        public long SubPickListDetailId { get; set; }
        public long SubPickListId { get; set; }
        public long AttributeInstanceId { get; set; }
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public string BatchDescription { get; set; }
        public double? ReceivingQuantity { get; set; }
    }
}

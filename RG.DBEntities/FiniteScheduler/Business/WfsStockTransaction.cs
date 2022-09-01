using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsStockTransaction
    {
        public long StockId { get; set; }
        public int DocumentTypeId { get; set; }
        public long DocumentNo { get; set; }
        public long ReceivingChallanId { get; set; }
        public long AttributeInstanceId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public double Quantity { get; set; }
        public long? ProcessId { get; set; }
        public long? OrderId { get; set; }
        public long? StyleId { get; set; }
        public int? SequenceNo { get; set; }
        public double? GarmentWeightPw { get; set; }
    }
}

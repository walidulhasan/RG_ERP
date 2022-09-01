using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblFlowDailyTransactionLog
    {
        public decimal TransId { get; set; }
        public long FlowId { get; set; }
        public long WcId { get; set; }
        public DateTime TransDate { get; set; }
        public long OrderId { get; set; }
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public int DocumentTypeId { get; set; }
        public long Quantity { get; set; }
        public int FabricCategoryId { get; set; }
        public int QualityId { get; set; }
    }
}

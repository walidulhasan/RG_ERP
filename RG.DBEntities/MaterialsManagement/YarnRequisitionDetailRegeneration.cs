using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnRequisitionDetailRegeneration
    {
        public int DetailId { get; set; }
        public int MrpitemCode { get; set; }
        public long? AttributeInstanceId { get; set; }
        public double? OriginalQty { get; set; }
        public double? BalanceQty { get; set; }
        public long YarnReqId { get; set; }
        public int? OrderId { get; set; }
        public int? StyleId { get; set; }
        public long? GrossId { get; set; }
        public double? GrossQty { get; set; }
        public double? NetQty { get; set; }
        public string ColorName { get; set; }
        public int MasterId { get; set; }
    }
}

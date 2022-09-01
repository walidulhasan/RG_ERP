using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnOrderDetail
    {
        public long Id { get; set; }
        public long Yomid { get; set; }
        public long? AttributeInstanceId { get; set; }
        public int? YarnNo { get; set; }
        public double? Utilization { get; set; }
        public int? MrpitemCode { get; set; }

        public virtual YarnOrderMaster Yom { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWoissuedYarnDetail
    {
        public long YarnWoissDetailId { get; set; }
        public int? MrpitemCode { get; set; }
        public long? AttributeInstanceId { get; set; }
        public double? OrderQty { get; set; }
        public int? UnitId { get; set; }
        public double? BalanceQty { get; set; }
        public double? TempBalanceQty { get; set; }
    }
}

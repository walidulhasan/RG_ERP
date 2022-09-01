using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnReturnToSupplierDetail
    {
        public long YrtsdetailId { get; set; }
        public long YrtsmasterId { get; set; }
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
        public int ReceivedQty { get; set; }
        public double ReturnedQty { get; set; }
        public long Amount { get; set; }
    }
}

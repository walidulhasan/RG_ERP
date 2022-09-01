using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WoGateReceivingDetail
    {
        public int Grdid { get; set; }
        public int Grid { get; set; }
        public int? ObjectId { get; set; }
        public int? AttributeInstanceId { get; set; }
        public double Quantity { get; set; }
        public int? StyleId { get; set; }
        public int? WodetailId { get; set; }
        public int? MrpitemCode { get; set; }
    }
}

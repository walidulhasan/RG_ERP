using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblGateReceivingDetail
    {
        [Key]
        public long Grdid { get; set; }
        public long ItemId { get; set; }
        public double Quantity { get; set; }
        public int Grid { get; set; }
        public int? DeliveryPoint { get; set; }

        public virtual CmblGateReceiving Gr { get; set; }
    }
}

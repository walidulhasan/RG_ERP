using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonGateReceivingDetail
    {
        [Key]
        public long Grdid { get; set; }
        public long AttributeInstanceId { get; set; }
        public double Quantity { get; set; }
        public int Grid { get; set; }
        public int? DeliveryPoint { get; set; }
    }
}

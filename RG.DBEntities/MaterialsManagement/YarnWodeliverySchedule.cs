using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWodeliverySchedule
    {
        public long YarnDelSchId { get; set; }
        public long? YarnWoid { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public double? DeliveryQty { get; set; }
    }
}

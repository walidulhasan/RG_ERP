using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeDyeingContractDeliveryScheduleDel
    {
        public long Id { get; set; }
        public long Dcid { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Weight { get; set; }
        public int DeliveryLocationId { get; set; }
    }
}

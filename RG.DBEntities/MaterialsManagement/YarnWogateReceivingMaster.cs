using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWogateReceivingMaster
    {
        public long YarnGateRecId { get; set; }
        public long? Woid { get; set; }
        public int? WotypeId { get; set; }
        public int? TwistCond { get; set; }
        public string DeliveryChallanNo { get; set; }
        public DateTime? DeliveryChallanDate { get; set; }
        public string DeliveryPerson { get; set; }
        public int? TempRecStatus { get; set; }
        public string YarnGateEntryNo { get; set; }
    }
}

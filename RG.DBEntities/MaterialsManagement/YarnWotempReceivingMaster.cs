using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWotempReceivingMaster
    {
        public long YarnTempRecId { get; set; }
        public long? YarnGateRecId { get; set; }
        public long? Woid { get; set; }
        public int? WeighingStatus { get; set; }
        public string YarnTempRecNo { get; set; }
        public string DeliveryChallanNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryPerson { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblGateReceiving
    {
        public CmblGateReceiving()
        {
            CmblGateReceivingDetail = new HashSet<CmblGateReceivingDetail>();
            CmblTemporaryReceiving = new HashSet<CmblTemporaryReceiving>();
        }
        [Key]
        public int Grid { get; set; }
        public int Poid { get; set; }
        public string DeliveryChallanNo { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public long CompanyId { get; set; }
        public int TempStatus { get; set; }
        public int Grno { get; set; }
        public int Deleted { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<CmblGateReceivingDetail> CmblGateReceivingDetail { get; set; }
        public virtual ICollection<CmblTemporaryReceiving> CmblTemporaryReceiving { get; set; }
    }
}

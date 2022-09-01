using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedGateReceivingMaster
    {
        public DyedGateReceivingMaster()
        {
            DyedGateReceivingDetail = new HashSet<DyedGateReceivingDetail>();
        }
        [Key]
        public int Grid { get; set; }
        public string DeliveryChallan { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Poid { get; set; }
        public string Grno { get; set; }
        public int Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<DyedGateReceivingDetail> DyedGateReceivingDetail { get; set; }
    }
}

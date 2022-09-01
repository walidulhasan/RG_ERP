using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_GateReceivingMaster
    {
        public Yarn_GateReceivingMaster()
        {
            YarnGateReceivingDetail = new HashSet<Yarn_GateReceivingDetail>();
            Yarn_TemporaryReceivingMaster = new HashSet<Yarn_TemporaryReceivingMaster>();
        }
        [Key]
        public long YarnGateRecID { get; set; }
        public long POID { get; set; }
        public string DeliveryChallanNo { get; set; }
        public DateTime DeliveryChallanDate { get; set; }
        public string DeliveryPerson { get; set; }
        public int TempRecStatus { get; set; }
        public string YarnGateEntryNo { get; set; }
        public long? CompanyID { get; set; }
        public int? BusinessID { get; set; }

        public virtual ICollection<Yarn_GateReceivingDetail> YarnGateReceivingDetail { get; set; }
         public virtual ICollection<Yarn_TemporaryReceivingMaster> Yarn_TemporaryReceivingMaster { get; set; }
    }
}

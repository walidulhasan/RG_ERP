using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.GateReceiving
{
    
    public partial class MM_GateReceiving
    {
        public MM_GateReceiving()
        {
            MM_GateReceivingDetail = new HashSet<MM_GateReceivingDetail>();
            MM_TempReceivingMaster = new HashSet<MM_TempReceivingMaster>();
        }
        [Key]
        public int GRID { get; set; }
        public string DeliveryChallan { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int POID { get; set; }
        public string GRNo { get; set; }
        public int Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UserID { get; set; }
        public int flag { get; set; }
        public long? CompanyID { get; set; }
        public long? BusinessID { get; set; }

        public virtual ICollection<MM_GateReceivingDetail> MM_GateReceivingDetail { get; set; }
        public virtual ICollection<MM_TempReceivingMaster> MM_TempReceivingMaster { get; set; }
    }
}

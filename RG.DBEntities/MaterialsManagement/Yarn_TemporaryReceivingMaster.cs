using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_TemporaryReceivingMaster
    {
        public Yarn_TemporaryReceivingMaster()
        {
            Yarn_InspectionMaster = new HashSet<Yarn_InspectionMaster>();
            Yarn_PermanentReceivingMaster = new HashSet<Yarn_PermanentReceivingMaster>();
        }
        [Key]
        public long YarnTempRecID { get; set; }
        [ForeignKey("Yarn_GateReceivingMaster")]
        public long YarnGateRecID { get; set; }
        public long POID { get; set; }
        public int WeighingStatus { get; set; }
        public int QualityStatus { get; set; }
        public string YarnTempRecNo { get; set; }
        public int? Status { get; set; }
        public string DeliveryChallanNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryPerson { get; set; }
        public long? CompanyID { get; set; }
        public int? BusinessID { get; set; }

        public virtual Yarn_GateReceivingMaster Yarn_GateReceivingMaster { get; set; }
         public virtual ICollection<Yarn_InspectionMaster> Yarn_InspectionMaster { get; set; }
      //  [NotMapped]
        public virtual ICollection<Yarn_PermanentReceivingMaster> Yarn_PermanentReceivingMaster { get; set; }
    }
}

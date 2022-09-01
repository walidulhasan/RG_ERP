using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_GateReceivingDetail
    {
        [Key]
        public long YarnGateRecDetailID { get; set; }
        [ForeignKey("Yarn_GateReceivingMaster")]
        public long YarnGateRecID { get; set; }
        public int MRPitemCode { get; set; }
        public long AttributeInstanceID { get; set; }
        public double ReceivingQTY { get; set; }
        public int UnitID { get; set; }
        public double Rate { get; set; }
        public int RateUnitID { get; set; }
        public double GST { get; set; }
        public int BrandID { get; set; }
        public int PackagingID { get; set; }
        public int ConesPerProcurementUnit { get; set; }
        public int NoOfDeliveries { get; set; }
        public long Yarn_PODetailID { get; set; }
        public int? IsRejected { get; set; }

        public virtual Yarn_GateReceivingMaster YarnGateRec { get; set; }
    }
}

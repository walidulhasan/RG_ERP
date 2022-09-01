using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnOutGatePassMaster
    {
        public YarnOutGatePassMaster()
        {
            YarnOutGatePassDetail = new HashSet<YarnOutGatePassDetail>();
        }
        [Key]
        public long YarnOutGatePassId { get; set; }
        public DateTime OutGatePassDate { get; set; }
        public long Poid { get; set; }
        public string ReceivingPerson { get; set; }
        public string VehicleNo { get; set; }
        public string IdentificationNo { get; set; }
        public int? Yrtsid { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<YarnOutGatePassDetail> YarnOutGatePassDetail { get; set; }
    }
}

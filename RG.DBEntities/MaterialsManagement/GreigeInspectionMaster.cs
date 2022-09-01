using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeInspectionMaster
    {
        public GreigeInspectionMaster()
        {
            GreigeInspectionDetail = new HashSet<GreigeInspectionDetail>();
            GreigeInspectionDetailFlatBed = new HashSet<GreigeInspectionDetailFlatBed>();
        }
        [Key]
        public int Gimid { get; set; }
        public int Gtrmid { get; set; }
        public string Ginsno { get; set; }
        public DateTime? InspectionDate { get; set; }
        public int Ykncid { get; set; }
        public int Grnstatus { get; set; }
        public int? OutGatePassStatus { get; set; }

        public virtual ICollection<GreigeInspectionDetail> GreigeInspectionDetail { get; set; }
        public virtual ICollection<GreigeInspectionDetailFlatBed> GreigeInspectionDetailFlatBed { get; set; }
    }
}

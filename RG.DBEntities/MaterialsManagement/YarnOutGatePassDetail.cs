using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnOutGatePassDetail
    {
        [Key]
        public long YarnOutwardDetailId { get; set; }
        public long YarnOutGatePassId { get; set; }
        public long YarnWeighInspId { get; set; }
        public long YarnTempRecId { get; set; }
        public long YarnGateReceving { get; set; }

        public virtual YarnOutGatePassMaster YarnOutGatePass { get; set; }
    }
}

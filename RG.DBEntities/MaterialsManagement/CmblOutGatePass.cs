using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblOutGatePass
    {
        [Key]
        public long Ogpid { get; set; }
        public string Ogpno { get; set; }
        public DateTime? Ogpdate { get; set; }
        public long? CompId { get; set; }
        public long? Minid { get; set; }
        public int? UserId { get; set; }
        public int? Poid { get; set; }

        public virtual CmblInspectionMain Min { get; set; }
    }
}

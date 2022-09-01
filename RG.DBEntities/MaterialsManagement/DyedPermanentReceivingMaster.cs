using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedPermanentReceivingMaster
    {
        [Key]
        public long PermRecId { get; set; }
        public DateTime? PermRecDate { get; set; }
        public int? Status { get; set; }
        public string PermRecNo { get; set; }
        public long? Diid { get; set; }
        public int? Dcid { get; set; }
    }
}

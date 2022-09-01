using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedInterOrderTransferMaster
    {
        [Key]
        public long Iotid { get; set; }
        public string Iotno { get; set; }
        public DateTime Iotdate { get; set; }
        public int UserId { get; set; }
    }
}

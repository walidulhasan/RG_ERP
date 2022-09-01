using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeInterOrderTransferMaster
    {
        [Key]
        public int Iotid { get; set; }
        public string Iotno { get; set; }
        public DateTime? Iotdate { get; set; }
        public int? UserId { get; set; }
    }
}

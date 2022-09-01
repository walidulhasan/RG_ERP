using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CMBL_InterOrderTransfer
    {
        [Key]
        public long Iotid { get; set; }
        public long Iotno { get; set; }
        public long CompanyId { get; set; }
        public int Deleted { get; set; }
        public string Comments { get; set; }
        public DateTime Iotdate { get; set; }
        public int UserId { get; set; }
    }
}

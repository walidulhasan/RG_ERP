using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class LcMtMasterType
    {
        [Key]
        public int LmtId { get; set; }
        public string LmtDesc { get; set; }
    }
}

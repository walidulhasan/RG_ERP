using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class MmpackagingSetup
    {  [Key]
        public int PackagingId { get; set; }
        public string PackagingDesc { get; set; }
    }
}

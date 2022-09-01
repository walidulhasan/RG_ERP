using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class MmnoOfPackagesSetup
    {[Key]
        public int NoOfPackagesId { get; set; }
        public string NoOfPackagesDesc { get; set; }
    }
}

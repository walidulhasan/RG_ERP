using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmReturnFromFloorMaster
    {
        [Key]
        public long Rffid { get; set; }
        public long? Miid { get; set; }
        public string Remarks { get; set; }

        public virtual MM_MaterialIssuanceMaster Mi { get; set; }
    }
}

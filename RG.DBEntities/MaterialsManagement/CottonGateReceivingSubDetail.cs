using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonGateReceivingSubDetail
    {
        [Key]
        public long Grsdid { get; set; }
        public long Grdid { get; set; }
        public string LotNo { get; set; }
        public int NoOfBales { get; set; }
    }
}

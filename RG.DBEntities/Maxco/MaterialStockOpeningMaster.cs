using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialStockOpeningMaster
    {
        [Key]
        public long Msomid { get; set; }
        public string ReferenceNo { get; set; }
        public string Remarks { get; set; }
        public DateTime Msodate { get; set; }
    }
}

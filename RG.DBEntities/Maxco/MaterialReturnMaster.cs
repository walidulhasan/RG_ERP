using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialReturnMaster
    {[Key]
        public int MreturnMid { get; set; }
        public DateTime ReturnDate { get; set; }
        public string OutGatePass { get; set; }
        public string Remarks { get; set; }
        public int? Mrmid { get; set; }
    }
}

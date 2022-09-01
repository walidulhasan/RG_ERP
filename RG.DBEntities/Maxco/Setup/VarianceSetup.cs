using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class VarianceSetup
    {
        [Key]
        public byte VarianceId { get; set; }
        public string VarianceDesc { get; set; }
    }
}

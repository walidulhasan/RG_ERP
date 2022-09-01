using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class tbl_KnittingRollsQuality_Setup
    {
       [Key]
        public int QualityID { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class QRM_CostingAllowancesSetup
    {
       [Key]
        public int CostingAllowanceID { get; set; }
        public string CostingAllowance { get; set; }
    }
}

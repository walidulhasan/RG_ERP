using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblStyleCostDetail
    {
        [Key]
        public long StyleCostId { get; set; }
        public int WcId { get; set; }
        public long UnitProduced { get; set; }
        public decimal Wccost { get; set; }
        public decimal PreDeptCost { get; set; }
        public decimal Variance { get; set; }

        public virtual TblStyleCost StyleCost { get; set; }
    }
}

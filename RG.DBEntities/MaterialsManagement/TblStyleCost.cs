using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblStyleCost
    {
        public TblStyleCost()
        {
            TblStyleCostDetail = new HashSet<TblStyleCostDetail>();
        }
        [Key]
        public long StyleCostId { get; set; }
        public long OrderId { get; set; }
        public long StyleId { get; set; }
        public long TotalUnit { get; set; }
        public decimal TotalActualCost { get; set; }
        public decimal TotalStdCost { get; set; }
        public decimal TotalVariance { get; set; }
        public DateTime Rdate { get; set; }
        public bool? IsDel { get; set; }

        public virtual ICollection<TblStyleCostDetail> TblStyleCostDetail { get; set; }
    }
}

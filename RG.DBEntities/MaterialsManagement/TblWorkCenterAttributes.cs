using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblWorkCenterAttributes
    {
        public TblWorkCenterAttributes()
        {
            TblWorkCenterAttributesDetail = new HashSet<TblWorkCenterAttributesDetail>();
        }
        [Key]
        public int WcId { get; set; }
        public int AvStrength { get; set; }
        public int AvMinPerDay { get; set; }
        public int WorkingDays { get; set; }
        public long AvCapacity { get; set; }
        public decimal AvgSalary { get; set; }
        public decimal AvgOverHead { get; set; }
        public decimal AppliedTime { get; set; }
        public decimal AppliedRate { get; set; }
        public decimal CostVariance { get; set; }
        public decimal Wastage { get; set; }
        public decimal OverheadRate { get; set; }
        public decimal MaterialCost { get; set; }
        public int TMonth { get; set; }
        public int TYear { get; set; }
        public bool? IsActive { get; set; }
        public long VerNo { get; set; }
        public DateTime? EDate { get; set; }
        public int Wuid { get; set; }

        public virtual ICollection<TblWorkCenterAttributesDetail> TblWorkCenterAttributesDetail { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblWorkCentreVariance
    {
        public decimal TransNo { get; set; }
        public decimal WcId { get; set; }
        public decimal TMonth { get; set; }
        public decimal TYear { get; set; }
        public decimal OrderId { get; set; }
        public decimal StyleId { get; set; }
        public decimal Variance { get; set; }
        public double StyleQty { get; set; }
        public double TotalWcproduction { get; set; }
        public double TotalWcvariance { get; set; }
        public double Material { get; set; }
        public double Labour { get; set; }
        public double OverHead { get; set; }
        public bool? IsDel { get; set; }
    }
}

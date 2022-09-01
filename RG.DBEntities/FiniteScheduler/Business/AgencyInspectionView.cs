using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AgencyInspectionView
    {
        public long AgencyInspectionId { get; set; }
        public int AgencyId { get; set; }
        public long ChallanNo { get; set; }
        public long StyleId { get; set; }
        public int DocumentTypeId { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public double? Expr1 { get; set; }
    }
}

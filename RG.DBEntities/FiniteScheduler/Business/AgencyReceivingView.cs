using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AgencyReceivingView
    {
        public long AgencyReceivingId { get; set; }
        public long ChallanNo { get; set; }
        public int DocumentTypeId { get; set; }
        public int MrpitemCode { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public double? Expr1 { get; set; }
        public long DocumentNo { get; set; }
        public long AgencyId { get; set; }
        public long StyleId { get; set; }
    }
}

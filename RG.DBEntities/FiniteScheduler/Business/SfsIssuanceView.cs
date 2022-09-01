using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsIssuanceView
    {
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long? Expr1 { get; set; }
        public long IssuanceId { get; set; }
    }
}

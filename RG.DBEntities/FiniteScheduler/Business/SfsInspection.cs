using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsInspection
    {
        public long JobId { get; set; }
        public long StyleId { get; set; }
        public long? Expr1 { get; set; }
        public long DocumentNo { get; set; }
        public DateTime InspectionDate { get; set; }
    }
}

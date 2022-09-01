using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class Rework
    {
        public string BarcodeNo { get; set; }
        public long StyleId { get; set; }
        public int? Expr1 { get; set; }
        public long ConfirmationId { get; set; }
    }
}

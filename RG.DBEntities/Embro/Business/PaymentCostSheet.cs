using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class PaymentCostSheet
    {
        public int Id { get; set; }
        public string Lcno { get; set; }
        public int? Coaid { get; set; }
        public decimal? Amount { get; set; }
    }
}

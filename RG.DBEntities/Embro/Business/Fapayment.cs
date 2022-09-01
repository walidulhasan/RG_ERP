using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class Fapayment
    {
        public decimal PaymentId { get; set; }
        public byte? PaymentType { get; set; }
        public decimal? Identifier { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class TblRfpCurrency
    {
        public long Rfpid { get; set; }
        public int? CurrencyId { get; set; }
        public double? Rate { get; set; }
    }
}

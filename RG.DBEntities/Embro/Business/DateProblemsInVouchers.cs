using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class DateProblemsInVouchers
    {
        public decimal Id { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherDate { get; set; }
        public string PrepareDate { get; set; }
    }
}

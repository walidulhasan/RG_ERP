using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class APM_Payroll_Detail
    {
        public decimal InvoiceID { get; set; }
        public decimal PayrollID { get; set; }
        public decimal? InvoiceEffect { get; set; }
    }
}

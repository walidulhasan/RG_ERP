using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class CbmPayrollBillToBill
    {
        public long? VoucherId { get; set; }
        public long? PayrollVoucherId { get; set; }
        public decimal? Payment { get; set; }
    }
}

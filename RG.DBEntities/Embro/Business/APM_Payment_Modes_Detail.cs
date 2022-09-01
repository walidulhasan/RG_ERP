using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class APM_Payment_Modes_Detail
    {
        public decimal MOPID { get; set; }
        public decimal SupplierID { get; set; }

        public virtual APM_Payment_Modes APM_Payment_Modes { get; set; }
        public virtual SupplierSetup Supplier { get; set; }
    }
}

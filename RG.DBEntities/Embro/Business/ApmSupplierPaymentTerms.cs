using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class ApmSupplierPaymentTerms
    {
        public decimal Topid { get; set; }
        public decimal TopsupplierId { get; set; }
        public decimal TopitemAccountId { get; set; }
        public string Topdescription { get; set; }
        public decimal Topterms { get; set; }
        public decimal Topdiscount { get; set; }

        public virtual BasicCOA BasicCOA { get; set; }
        public virtual SupplierSetup Topsupplier { get; set; }
    }
}

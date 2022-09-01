using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class ValuationClass
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int? ContraClassID { get; set; }
        public int ParentID { get; set; }
        public int CompanyID { get; set; }
        public int BusinessID { get; set; }
        public int? LocationID { get; set; }
        public int? SalesTaxAccount { get; set; }
        public int? IncomeTaxAccount { get; set; }
        public int CostCentreID { get; set; }
        public int ActivityID { get; set; }
    }
}

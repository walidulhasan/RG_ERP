﻿using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmValuationClass
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int ParentId { get; set; }
        public int CompanyId { get; set; }
        public int BusinessId { get; set; }
        public int? LocationId { get; set; }
        public int? SalesTaxAccount { get; set; }
        public int? IncomeTaxAccount { get; set; }
        public int CostCentreId { get; set; }
        public int ActivityId { get; set; }
    }
}

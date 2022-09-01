﻿using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Setup
{
    public partial class TrimTaxationSetup
    {
        public long SupplierId { get; set; }
        public long AccountId { get; set; }
        public string TaxType { get; set; }
        public double Percentage { get; set; }
        public int Id { get; set; }
        public int FiscalYear { get; set; }
    }
}

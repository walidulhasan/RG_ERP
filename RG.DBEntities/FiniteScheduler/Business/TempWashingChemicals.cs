using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TempWashingChemicals
    {
        public double? SNo { get; set; }
        public double? Code { get; set; }
        public string Description { get; set; }
        public double? Rate { get; set; }
        public string Supplier { get; set; }
        public string Purpose { get; set; }
        public string Usage { get; set; }
    }
}

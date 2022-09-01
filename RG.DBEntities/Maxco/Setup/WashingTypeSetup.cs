using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class WashingTypeSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double? Rate { get; set; }
        public int? CurrencyId { get; set; }
    }
}

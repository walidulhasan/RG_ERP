using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ProfitPercentageSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? Percentage { get; set; }
    }
}

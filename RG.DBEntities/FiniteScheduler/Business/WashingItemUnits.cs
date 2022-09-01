using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingItemUnits
    {
        public int UnitId { get; set; }
        public string UnitDesc { get; set; }
        public bool? IsBaseUnit { get; set; }
        public string UnitShortName { get; set; }
        public int? BaseUnitId { get; set; }
        public double? ConversionToBaseUnit { get; set; }
        public int? CmblunitId { get; set; }
    }
}

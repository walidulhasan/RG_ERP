using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingTimeAndTempUnit
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public string UnitShortName { get; set; }
        public bool? IsBaseUnit { get; set; }
        public double? ConversionToBaseUnit { get; set; }
    }
}

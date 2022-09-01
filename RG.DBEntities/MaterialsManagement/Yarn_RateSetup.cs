using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_RateSetup
    {
        [Key]
        public int RateID { get; set; }
        public decimal RateValue { get; set; }
        public string RateDisplayName { get; set; }
        public byte RateUnit { get; set; }
        public decimal SKUConversion { get; set; }
        public decimal? SKUConvertedValue { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnRateWeightSetup
    {
        public int Id { get; set; }
        public int WeightId { get; set; }
        public string WeightDesc { get; set; }
        public double ConversionToSku { get; set; }
    }
}

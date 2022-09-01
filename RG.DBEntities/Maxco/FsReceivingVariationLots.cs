using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsReceivingVariationLots
    {
        public int Id { get; set; }
        public int VariationId { get; set; }
        public string LotNo { get; set; }
        public int Inspected { get; set; }
        public string CircularXml { get; set; }
        public string FlatBedXml { get; set; }
        public string GreigeXml { get; set; }

        public virtual FsReceivingVariations Variation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsReceivingLotVariations
    {
        public FsReceivingLotVariations()
        {
            FsLotVariationQuantities = new HashSet<FsLotVariationQuantities>();
        }

        public int Id { get; set; }
        public int LotId { get; set; }
        public string VariationNo { get; set; }
        public int Inspected { get; set; }
        public string FabricsXml { get; set; }

        public virtual FsReceivingLots Lot { get; set; }
        public virtual ICollection<FsLotVariationQuantities> FsLotVariationQuantities { get; set; }
    }
}

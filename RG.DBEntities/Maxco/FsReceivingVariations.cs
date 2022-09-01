using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsReceivingVariations
    {
        public FsReceivingVariations()
        {
            FsReceivingVariationLots = new HashSet<FsReceivingVariationLots>();
        }

        public int Id { get; set; }
        public int ReceivingId { get; set; }
        public string VariationNo { get; set; }

        public virtual FsReceivingMaster Receiving { get; set; }
        public virtual ICollection<FsReceivingVariationLots> FsReceivingVariationLots { get; set; }
    }
}

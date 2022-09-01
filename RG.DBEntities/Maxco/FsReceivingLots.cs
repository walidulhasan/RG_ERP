using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsReceivingLots
    {
        public FsReceivingLots()
        {
            FsReceivingLotVariations = new HashSet<FsReceivingLotVariations>();
        }

        public int Id { get; set; }
        public int ReceivingId { get; set; }
        public string LotNo { get; set; }

        public virtual FsReceivingMaster Receiving { get; set; }
        public virtual ICollection<FsReceivingLotVariations> FsReceivingLotVariations { get; set; }
    }
}

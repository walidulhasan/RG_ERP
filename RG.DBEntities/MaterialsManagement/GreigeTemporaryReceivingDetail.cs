using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeTemporaryReceivingDetail
    {
        public long Id { get; set; }
        public int Gtrmid { get; set; }
        public int SizeId { get; set; }
        public double RecQty { get; set; }
        public int RecPcs { get; set; }

        public virtual GreigeTemporaryReceivingMaster Gtrm { get; set; }
    }
}

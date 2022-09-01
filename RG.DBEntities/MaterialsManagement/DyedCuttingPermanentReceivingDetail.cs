using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedCuttingPermanentReceivingDetail
    {
        public long DetailId { get; set; }
        public long PermRecId { get; set; }
        public long Fid { get; set; }
        public double Quantity { get; set; }
    }
}

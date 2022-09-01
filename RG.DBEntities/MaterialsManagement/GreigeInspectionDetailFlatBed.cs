using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeInspectionDetailFlatBed
    {
        public long Id { get; set; }
        public int Gimid { get; set; }
        public int SizeId { get; set; }
        public double AcceptedQty { get; set; }
        public int AcceptedPcs { get; set; }

        public virtual GreigeInspectionMaster Gim { get; set; }
    }
}

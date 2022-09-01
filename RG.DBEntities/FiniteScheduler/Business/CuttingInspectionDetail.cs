using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CuttingInspectionDetail
    {
        public int CuttingInspectionDetailId { get; set; }
        public int CuttingInspectionMasterId { get; set; }
        public int CuttingInpectionParameterId { get; set; }
        public int Result { get; set; }

        public virtual InspectionParameter CuttingInpectionParameter { get; set; }
        public virtual CuttingInspectionMaster CuttingInspectionMaster { get; set; }
    }
}

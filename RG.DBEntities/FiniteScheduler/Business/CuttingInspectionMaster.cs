using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CuttingInspectionMaster
    {
        public CuttingInspectionMaster()
        {
            CuttingInspectionDetail = new HashSet<CuttingInspectionDetail>();
        }

        public int CuttingInspectionMasterId { get; set; }
        public DateTime CuttingInspectionDate { get; set; }
        public int UserId { get; set; }
        public int ReceivedFabricDetailId { get; set; }
        public int SampleSize { get; set; }

        public virtual ICollection<CuttingInspectionDetail> CuttingInspectionDetail { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWoweighingInspectionMaster
    {
        public long YarnWeighInspId { get; set; }
        public long? YarnTempRecId { get; set; }
        public long? Woid { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string InspectionNo { get; set; }
        public int? UserId { get; set; }
        public int? PermReceivingDone { get; set; }
    }
}

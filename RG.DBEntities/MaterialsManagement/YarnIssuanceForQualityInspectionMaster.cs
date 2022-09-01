using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnIssuanceForQualityInspectionMaster
    {
        public long YarnIssQltyid { get; set; }
        public long YarnWeighInspId { get; set; }
        public long YarnTempRecId { get; set; }
    }
}

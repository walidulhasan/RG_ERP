using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeInspectionDetail
    {
        public long Id { get; set; }
        public int Gimid { get; set; }
        public int QualityAttributeId { get; set; }
        public string QualityAttributeValue { get; set; }
        public bool? Status { get; set; }
        public string Comments { get; set; }

        public virtual GreigeInspectionMaster Gim { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedInspectionDetail
    {
        public long Id { get; set; }
        public long Diid { get; set; }
        public string RollNo { get; set; }
        public int QualityAttributeId { get; set; }
        public string QualityAttributeValue { get; set; }
    }
}

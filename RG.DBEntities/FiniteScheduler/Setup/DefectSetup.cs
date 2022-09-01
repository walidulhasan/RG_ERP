using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class DefectSetup
    {
        public long DefectId { get; set; }
        public string Defect { get; set; }
        public int WorkCenterId { get; set; }
        public int? DefectCategoryId { get; set; }
    }
}

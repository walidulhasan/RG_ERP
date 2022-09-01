using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsInspectionMaster
    {
        public long InspectionId { get; set; }
        public long JobId { get; set; }
        public DateTime InspectionDate { get; set; }
        public string Comments { get; set; }
    }
}

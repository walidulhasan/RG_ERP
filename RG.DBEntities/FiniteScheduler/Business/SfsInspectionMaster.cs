using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsInspectionMaster
    {
        public long InspectionId { get; set; }
        public long JobId { get; set; }
        public long StyleId { get; set; }
        public DateTime InspectionDate { get; set; }
        public int Deleted { get; set; }
        public int? IsbarCode { get; set; }
    }
}

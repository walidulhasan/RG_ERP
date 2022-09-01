using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsInspectionDefect
    {
        public long Id { get; set; }
        public long DefectId { get; set; }
        public int IsMinor { get; set; }
        public int IsMajor { get; set; }
        public int IsCritical { get; set; }
        public long? SfsinspectionId { get; set; }
        public long? Quantity { get; set; }
        public int? JobId { get; set; }
        public int? LevelNo { get; set; }
        public int? IsFinishing { get; set; }
    }
}

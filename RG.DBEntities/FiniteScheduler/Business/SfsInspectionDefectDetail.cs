using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsInspectionDefectDetail
    {
        public long Id { get; set; }
        public long MasterId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long SerialNo { get; set; }
        public byte[] DefectedGarmentImg { get; set; }
        public long? StyleId { get; set; }
        public long? AuditId { get; set; }
    }
}

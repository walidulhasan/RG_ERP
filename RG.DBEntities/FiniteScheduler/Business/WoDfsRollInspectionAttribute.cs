using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WoDfsRollInspectionAttribute
    {
        public long Id { get; set; }
        public long? InspectionId { get; set; }
        public long? DcrollAttributeId { get; set; }
        public long? RollId { get; set; }
        public string RollNo { get; set; }
        public string Quantity { get; set; }
        public long? Ykncid { get; set; }
        public long? MachineId { get; set; }
        public long? DcgattributeInstanceId { get; set; }
    }
}

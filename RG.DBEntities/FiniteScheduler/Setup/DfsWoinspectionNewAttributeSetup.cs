using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class DfsWoinspectionNewAttributeSetup
    {
        public long Id { get; set; }
        public long? OldDcgattributeInstanceId { get; set; }
        public long? NewDcgattributeInstanceId { get; set; }
        public long? RollId { get; set; }
        public string RollNo { get; set; }
        public long? Ykncid { get; set; }
        public long? MachineId { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedIssuanceDetail
    {
        public long Id { get; set; }
        public long IssuanceId { get; set; }
        public long Fid { get; set; }
        public long DyedAttributeInstanceId { get; set; }
        public long RollId { get; set; }
        public string RollNo { get; set; }
        public long AssignmentId { get; set; }
    }
}

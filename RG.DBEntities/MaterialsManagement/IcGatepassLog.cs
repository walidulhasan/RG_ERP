using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcGatepassLog
    {
        public long Id { get; set; }
        public long? GatepassId { get; set; }
        public string GatepassNo { get; set; }
        public string Comments { get; set; }
        public DateTime? CommentsDate { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}

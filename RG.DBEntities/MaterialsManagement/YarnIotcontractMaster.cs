using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnIotcontractMaster
    {
        public long Iotid { get; set; }
        public long? OldOrderId { get; set; }
        public string OldOrderNo { get; set; }
        public long? OldProgramTypeId { get; set; }
        public long? NewOrderId { get; set; }
        public string NewOrderNo { get; set; }
        public long? NewProgramTypeId { get; set; }
    }
}

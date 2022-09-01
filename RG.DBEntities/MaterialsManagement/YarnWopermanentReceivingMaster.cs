using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWopermanentReceivingMaster
    {
        public long YarnPermRecId { get; set; }
        public long? YarnTempRecId { get; set; }
        public long? YarnWeighingId { get; set; }
        public string YarnPermRecNo { get; set; }
        public DateTime? YarnPermRecDate { get; set; }
        public long? Woid { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnIotmaster
    {
        public long Iotid { get; set; }
        public DateTime? Iotdate { get; set; }
        public string Iotno { get; set; }
        public int? OldProgramId { get; set; }
        public long? OldOrderId { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MrpitemAttributeSetValues
    {
        public int Id { get; set; }
        public long Mavid { get; set; }
        public long MattributeId { get; set; }
        public string MavalueId { get; set; }
        public string MavalueDescription { get; set; }
        public long AttributeInstanceId { get; set; }

        public virtual MrpitemAttributeInstance AttributeInstance { get; set; }
        public virtual MrpitemAttributeSet Mattribute { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MrpitemAttributeSet
    {
        public MrpitemAttributeSet()
        {
            MrpitemAttributeSetValues = new HashSet<MrpitemAttributeSetValues>();
        }
        public int Id { get; set; }
        public long MattributeId { get; set; }
        public int MrpitemCode { get; set; }
        public int AttributeId { get; set; }
        public bool IsPlanning { get; set; }
        public bool IsVisible { get; set; }
        public string DefaultValue { get; set; }
        public int? Priority { get; set; }

        public virtual MrpitemMasterAttribute Attribute { get; set; }
        public virtual ICollection<MrpitemAttributeSetValues> MrpitemAttributeSetValues { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MrpitemMasterAttribute
    {
        public MrpitemMasterAttribute()
        {
            MrpitemAttributeSet = new HashSet<MrpitemAttributeSet>();
        }
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public string Aname { get; set; }

        public virtual ICollection<MrpitemAttributeSet> MrpitemAttributeSet { get; set; }
    }
}

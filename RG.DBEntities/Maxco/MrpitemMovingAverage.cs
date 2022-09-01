using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MrpitemMovingAverage
    {
        public int Id { get; set; }
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
        public double MovingAverage { get; set; }

        public virtual MrpitemAttributeInstance AttributeInstance { get; set; }
    }
}

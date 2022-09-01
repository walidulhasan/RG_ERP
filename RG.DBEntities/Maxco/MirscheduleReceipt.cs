using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MirscheduleReceipt
    {
        public int Id { get; set; }
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
        public int DayId { get; set; }
        public double Quantity { get; set; }

        public virtual MrpitemAttributeInstance AttributeInstance { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MirgrossNet
    {
        public int Id { get; set; }
        public int? ObjectId { get; set; }
        public long AttributeInstanceId { get; set; }
        public int MrpitemCode { get; set; }
        public double Gross { get; set; }
        public int DayId { get; set; }
        public double Net { get; set; }
        public int PodayId { get; set; }
        public int? SuperBomid { get; set; }

        public virtual MrpitemAttributeInstance AttributeInstance { get; set; }
    }
}

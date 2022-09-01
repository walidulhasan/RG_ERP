using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class MinuteType
    {
        public MinuteType()
        {
            MinuteTime = new HashSet<MinuteTime>();
        }

        public int MinuteTypeId { get; set; }
        public string MinuteTypeName { get; set; }
        public string MinuteTypeDescription { get; set; }

        public virtual ICollection<MinuteTime> MinuteTime { get; set; }
    }
}

using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class MinuteTime
    {
        public MinuteTime()
        {
            CuttingMachineLoad = new HashSet<CuttingMachineLoad>();
            SfsLoads = new HashSet<SfsLoads>();
            SpreaderLoad = new HashSet<SpreaderLoad>();
            TableLoad = new HashSet<TableLoad>();
        }

        public int MinuteId { get; set; }
        public DateTime DayMinute { get; set; }
        public int MinuteTypeId { get; set; }

        public virtual MinuteType MinuteType { get; set; }
        public virtual ICollection<CuttingMachineLoad> CuttingMachineLoad { get; set; }
        public virtual ICollection<SfsLoads> SfsLoads { get; set; }
        public virtual ICollection<SpreaderLoad> SpreaderLoad { get; set; }
        public virtual ICollection<TableLoad> TableLoad { get; set; }
    }
}

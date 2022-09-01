using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GeThreadBreakageAllowance
    {
        public int Id { get; set; }
        public int ThreadBreakage { get; set; }
        public int NeedleBreakage { get; set; }
        public int MachineBreakDown { get; set; }
        public int MachineSetting { get; set; }
        public int? GarmentType { get; set; }
    }
}

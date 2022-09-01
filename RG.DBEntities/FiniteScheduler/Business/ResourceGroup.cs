using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class ResourceGroup
    {
        public int ResourceGroupId { get; set; }
        public int CuttingMachineInstanceId { get; set; }
        public int SpreadingMachineInstanceId { get; set; }
        public int TableId { get; set; }

        public virtual CuttingMachineInstance CuttingMachineInstance { get; set; }
        public virtual SpreaderInstance SpreadingMachineInstance { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CuttingOperation
    {
        public CuttingOperation()
        {
            MachineOperation = new HashSet<MachineOperation>();
        }

        public int CuttingOperationId { get; set; }
        public string CuttingOperationName { get; set; }

        public virtual ICollection<MachineOperation> MachineOperation { get; set; }
    }
}

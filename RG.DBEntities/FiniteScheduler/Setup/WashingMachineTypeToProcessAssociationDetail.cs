using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingMachineTypeToProcessAssociationDetail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int MachineTypeId { get; set; }
        public int? FabricCategoryId { get; set; }
        public int ProcessCodeId { get; set; }
        public bool? IsWetProcess { get; set; }
    }
}

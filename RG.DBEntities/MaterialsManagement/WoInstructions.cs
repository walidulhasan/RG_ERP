using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WoInstructions
    {
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public string Instruction { get; set; }
    }
}

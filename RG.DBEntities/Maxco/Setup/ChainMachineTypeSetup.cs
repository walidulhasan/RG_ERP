using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ChainMachineTypeSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? DepartmentId { get; set; }
        public double? NoOfNeedles { get; set; }
        public double? NoOfLoppers { get; set; }
        public int Category { get; set; }
        public int? FammachineTypeId { get; set; }
        public string FammachineTypeName { get; set; }
    }
}

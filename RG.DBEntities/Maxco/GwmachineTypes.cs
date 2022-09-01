using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class GwmachineTypes
    {
       [Key]
        public long GwmachineTypeId { get; set; }
        public string GwmachineTypeName { get; set; }
        public double GwmachineCapacity { get; set; }
        public double CycleTime { get; set; }
        public double Rate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? FamMachineId { get; set; }
    }
}

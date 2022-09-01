using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class GwmanualOperation
    {
       [Key]
        public long GwmanualOperationId { get; set; }
        public string GwmachineOperationName { get; set; }
        public int NoOfPersons { get; set; }
        public double Smv { get; set; }
        public double? Rate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

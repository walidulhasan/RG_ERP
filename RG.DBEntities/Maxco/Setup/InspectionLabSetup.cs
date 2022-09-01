using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class InspectionLabSetup
    {
        [Key]
        public int InspectionLabId { get; set; }
        public string InspectionLabDescription { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeMovingAverage
    {
        [Key]
        public long AttributeInstanceId { get; set; }
        public double? MovingAverage { get; set; }
    }
}

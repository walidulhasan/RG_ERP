using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.DBViews
{
   public class viw_CurrentMovingAverageForAttributeInstance
    {
      
        public long? AttributeInstanceID { get; set; }
        public decimal? MovingAverage { get; set; }
    }
}

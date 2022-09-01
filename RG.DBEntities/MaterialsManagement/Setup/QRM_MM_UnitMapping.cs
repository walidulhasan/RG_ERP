using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
   public class QRM_MM_UnitMapping
    {[Key]
        public int MeasurementScaleID { get; set; }
        public int MRPUnitsID { get; set; }
    }
}

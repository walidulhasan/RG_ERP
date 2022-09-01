using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
  public  class MM_MRPItemUnits 
    {
        [Key]
        public int MRPItemUnitID { get; set; }
        [ForeignKey("MM_MRPUnits")]
        public int MRPUnitsID { get; set; }
        public int MRPItemCode { get; set; }
        public double? ConversiontoSKU { get; set; }

        public virtual MM_MRPUnits MM_MRPUnits { get; set; }
    }
}

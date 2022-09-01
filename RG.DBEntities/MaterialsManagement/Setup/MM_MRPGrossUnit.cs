using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
  public partial  class MM_MRPGrossUnit 
    {
        public int ID { get; set; }
        [ForeignKey("MM_MRPItem")]
        public int MRPItemCode { get; set; }
        public int GrossUnitID { get; set; }
       public virtual MM_MRPItem MM_MRPItem { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
  public partial class MM_MRPItemAttributeSetValues 
    {
                [Key]
        public long MAVID { get; set; }
        public long MAttributeID { get; set; }
        public string MAValueID { get; set; }
        public string MAValueDescription { get; set; }
        public long AttributeInstanceID { get; set; }

        public virtual MM_MRPItemAttributeInstance AttributeInstance { get; set; }
        public virtual MM_MRPItemAttributeSet Mattribute { get; set; }
    }
}

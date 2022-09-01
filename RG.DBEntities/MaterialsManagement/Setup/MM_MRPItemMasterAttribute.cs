using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
  public partial  class MM_MRPItemMasterAttribute
    {
        public MM_MRPItemMasterAttribute()
        {
            MM_MRPItemAttributeSet = new HashSet<MM_MRPItemAttributeSet>();
        }
        [Key]
        public int AttributeID { get; set; }
        public string Aname { get; set; }
        public int? AttributeType { get; set; }

        public virtual ICollection<MM_MRPItemAttributeSet> MM_MRPItemAttributeSet { get; set; }
    }
}

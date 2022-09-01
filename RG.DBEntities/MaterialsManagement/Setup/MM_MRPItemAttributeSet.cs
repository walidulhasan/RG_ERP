using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
  public partial  class MM_MRPItemAttributeSet 
    {
        public MM_MRPItemAttributeSet()
        {
            MM_MRPItemAttributeSetValues = new HashSet<MM_MRPItemAttributeSetValues>();
        }
        [Key]
        public long MattributeID { get; set; }
        public int MrpitemCode { get; set; }
        public int AttributeID { get; set; }
        public bool IsPlanning { get; set; }
        public bool IsVisible { get; set; }
        public string DefaultValue { get; set; }
        public int? Priority { get; set; }
        public bool? IsHighLevel { get; set; }

        public virtual MM_MRPItemMasterAttribute MM_MRPItemMasterAttribute { get; set; }
        public virtual MM_MRPItem MM_MRPItem { get; set; }
        public virtual ICollection<MM_MRPItemAttributeSetValues> MM_MRPItemAttributeSetValues { get; set; }
    }
}

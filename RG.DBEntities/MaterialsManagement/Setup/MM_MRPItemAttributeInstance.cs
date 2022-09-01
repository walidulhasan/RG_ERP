using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
   public partial class MM_MRPItemAttributeInstance 
    {
        public MM_MRPItemAttributeInstance()
        {
            MM_MRPItemAttributeSetValues = new HashSet<MM_MRPItemAttributeSetValues>();
        }
        [Key]
        public long AttributeInstanceID { get; set; }
        public string Adesc { get; set; }
        public double MovingAverage { get; set; }
        public string AttributesXml { get; set; }
        public int? AttributeCount { get; set; }
        public string ValueDescription { get; set; }
        public int? StockQuantity { get; set; }

        public virtual ICollection<MM_MRPItemAttributeSetValues> MM_MRPItemAttributeSetValues { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class MaterialOperation_Setup
    {
        public MaterialOperation_Setup()
        {
           // MaterialOperationVendor = new HashSet<MaterialOperationVendor>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

       // public virtual ICollection<MaterialOperationVendor> MaterialOperationVendor { get; set; }
    }
}

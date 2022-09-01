using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdunitSetup
    {
        public DdunitSetup()
        {
            DdsupplierItem = new HashSet<DdsupplierItem>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DdsupplierItem> DdsupplierItem { get; set; }
    }
}

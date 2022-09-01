using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DditemCatagorySetup
    {
        public DditemCatagorySetup()
        {
            DdsupplierDomain = new HashSet<DdsupplierDomain>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsMrp { get; set; }

        public virtual ICollection<DdsupplierDomain> DdsupplierDomain { get; set; }
    }
}

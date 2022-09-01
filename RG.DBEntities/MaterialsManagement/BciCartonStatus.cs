using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCartonStatus
    {
        public BciCartonStatus()
        {
            BciCartonSetupMaster = new HashSet<BciCartonSetupMaster>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BciCartonSetupMaster> BciCartonSetupMaster { get; set; }
    }
}

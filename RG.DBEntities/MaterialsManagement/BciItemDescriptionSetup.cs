using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciItemDescriptionSetup
    {
        public int Id { get; set; }
        public string ItemDescriptionName { get; set; }
        public int BciItemSetupId { get; set; }

        public virtual BciItemSetup BciItemSetup { get; set; }
    }
}

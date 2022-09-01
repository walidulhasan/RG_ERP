using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciItemSetup
    {
        public BciItemSetup()
        {
            BciItemDescriptionSetup = new HashSet<BciItemDescriptionSetup>();
        }

        public int Id { get; set; }
        public string ItemName { get; set; }

        public virtual ICollection<BciItemDescriptionSetup> BciItemDescriptionSetup { get; set; }
    }
}

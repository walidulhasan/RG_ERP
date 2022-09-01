using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdnonmrpitemTypeSetup
    {
        public DdnonmrpitemTypeSetup()
        {
            DdnonmrpitemSetup = new HashSet<DdnonmrpitemSetup>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int ItemCatagoryId { get; set; }

        public virtual ICollection<DdnonmrpitemSetup> DdnonmrpitemSetup { get; set; }
    }
}

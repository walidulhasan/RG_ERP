using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdreasonTypeSetup
    {
        public DdreasonTypeSetup()
        {
            DdreasonsSetup = new HashSet<DDReasons_Setup>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DDReasons_Setup> DdreasonsSetup { get; set; }
    }
}

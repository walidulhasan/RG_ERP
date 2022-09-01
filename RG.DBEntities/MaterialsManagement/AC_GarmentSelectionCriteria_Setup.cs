using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class AC_GarmentSelectionCriteria_Setup
    {
        public AC_GarmentSelectionCriteria_Setup()
        {
            AcGarmentSelectionCriteria = new HashSet<AC_GarmentSelectionCriteria>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AC_GarmentSelectionCriteria> AcGarmentSelectionCriteria { get; set; }
    }
}

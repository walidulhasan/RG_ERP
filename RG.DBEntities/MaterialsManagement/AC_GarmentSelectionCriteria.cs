using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class AC_GarmentSelectionCriteria
    {
        public long Id { get; set; }
        public int WorkCenterId { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public byte GarmentCriteriaId { get; set; }
        public int TrimId { get; set; }
        public long? Version { get; set; }

        public virtual AC_GarmentSelectionCriteria_Setup GarmentCriteria { get; set; }
    }
}

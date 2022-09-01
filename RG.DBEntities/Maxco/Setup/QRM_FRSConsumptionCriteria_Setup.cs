using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class QRM_FRSConsumptionCriteria_Setup
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int? SelectedFRSConsumption { get; set; }
    }
}

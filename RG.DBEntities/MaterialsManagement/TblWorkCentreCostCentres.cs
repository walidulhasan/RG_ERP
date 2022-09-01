using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblWorkCentreCostCentres
    {
        public decimal? WcId { get; set; }
        public decimal? CostCentreId { get; set; }
        public int? MjrHead { get; set; }
    }
}

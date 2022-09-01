using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblWorkCentreCostingProcess
    {
        public decimal WcId { get; set; }
        public decimal Mrpitem { get; set; }
        public string Descrip { get; set; }
    }
}

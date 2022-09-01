using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DefectCategory
    {
        public int DefectCategoryId { get; set; }
        public string DefectDescription { get; set; }
        public int WorkCentreId { get; set; }
    }
}

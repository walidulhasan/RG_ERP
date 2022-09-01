using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsPrselectedGarmentCategory
    {
        public int Id { get; set; }
        public int GarmentCategoryId { get; set; }
        public string GarmentCategory { get; set; }
        public int SfsPrsid { get; set; }
    }
}

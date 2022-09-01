using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class SfsPrselectedGarmentType
    {
        public int Id { get; set; }
        public int GarmentTypeId { get; set; }
        public string GarmentType { get; set; }
        public int SfsPrsid { get; set; }
    }
}

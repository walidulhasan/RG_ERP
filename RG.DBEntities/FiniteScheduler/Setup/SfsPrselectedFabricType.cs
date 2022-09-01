using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class SfsPrselectedFabricType
    {
        public int Id { get; set; }
        public int FabricTypeId { get; set; }
        public string FabricType { get; set; }
        public int SfsPrsid { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FinishedFabricFinishing
    {
        public int Id { get; set; }
        public int? FinishedFabricId { get; set; }
        public string FinishingTypeId { get; set; }
    }
}

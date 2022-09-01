using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TieDyedSpotDyedSpecification
    {
        public int Id { get; set; }
        public long? ColorSetId { get; set; }
        public string PantoneNo { get; set; }
        public int? DyeingTypeId { get; set; }
        public string ProcessLocation { get; set; }
    }
}

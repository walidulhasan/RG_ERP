using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelYarnConsumption
    {
        public long Id { get; set; }
        public long StyleId { get; set; }
        public int YarnCompositionId { get; set; }
        public int YarnQualityId { get; set; }
        public int YarnCountId { get; set; }
        public bool IsDyed { get; set; }
        public string ColorType { get; set; }
        public string PantoneNo { get; set; }
        public int YarnDyeingId { get; set; }
        public int UnitId { get; set; }
    }
}

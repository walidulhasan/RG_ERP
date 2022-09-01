using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SampleMirgreigeFabric
    {
        public int? Id { get; set; }
        public int? TypeId { get; set; }
        public int? QualityId { get; set; }
        public string FabricComposition { get; set; }
        public int? GaugeId { get; set; }
        public int? Gsm { get; set; }
        public int? MachineTypeId { get; set; }
        public int? DyeingTypeId { get; set; }
        public int? Gross { get; set; }
        public double? AtHand { get; set; }
        public double? Sr { get; set; }
        public double? Net { get; set; }
        public double? StyleId { get; set; }
        public double? Spandex { get; set; }
        public int? JobNo { get; set; }
        public double? AllocatedAtHand { get; set; }
    }
}

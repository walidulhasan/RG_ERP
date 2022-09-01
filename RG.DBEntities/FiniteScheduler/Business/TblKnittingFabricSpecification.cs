using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingFabricSpecification
    {
        public long FabricSpecificationId { get; set; }
        public int TypeId { get; set; }
        public int QualityId { get; set; }
        public int Gsm { get; set; }
        public int DesignId { get; set; }
        public int MachineTypeId { get; set; }
        public int GaugeId { get; set; }
    }
}

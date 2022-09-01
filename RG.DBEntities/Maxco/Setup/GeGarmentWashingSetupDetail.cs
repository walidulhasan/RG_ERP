using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GeGarmentWashingSetupDetail
    {
        public int Id { get; set; }
        public long GwdId { get; set; }
        public long GwId { get; set; }
        public long GwOperationId { get; set; }
        public int GwOperationSequence { get; set; }
        public double GwOperationSmv { get; set; }
        public double GwOperationRate { get; set; }
        public double GwOperationHp { get; set; }
        public double GwOperartionDp { get; set; }
    }
}

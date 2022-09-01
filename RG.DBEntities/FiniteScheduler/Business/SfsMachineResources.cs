using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsMachineResources
    {
        public long FixedAssetId { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SfsPrsid { get; set; }
        public int Status { get; set; }
        public long? FammachineTypeId { get; set; }
        public int? MachineStatus { get; set; }
    }
}

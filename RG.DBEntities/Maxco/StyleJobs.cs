using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class StyleJobs
    {
        public int Id { get; set; }
        public long JobId { get; set; }
        public long StyleId { get; set; }
        public int FabricTypeId { get; set; }
        public int FabricQualityId { get; set; }
        public string FabricComposition { get; set; }
        public int MachineTypeId { get; set; }
        public int Gsm { get; set; }
        public int IsSpandex { get; set; }
        public int? Version { get; set; }
    }
}

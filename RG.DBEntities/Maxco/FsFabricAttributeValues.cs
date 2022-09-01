using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class FsFabricAttributeValues
    {
        [Key]
        public long AttributeInstanceId { get; set; }
        public int? DemandSource { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public int Gsm { get; set; }
        public int FinishedWidth { get; set; }
        public string FabricComposition { get; set; }
        public string DyeingLevel { get; set; }
        public string MachineType { get; set; }
        public int? IsSpandex { get; set; }
        public string DyeingProcess { get; set; }
        public string PantoneNo { get; set; }
        public string MatchingSource { get; set; }
    }
}

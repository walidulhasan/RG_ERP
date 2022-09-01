using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnInspectionDetail
    {
        [Key]
        public int YinspectionDid { get; set; }
        public int MinspectionMid { get; set; }
        public int SourceYarnIqid { get; set; }
        public int DestinationYarnIqid { get; set; }
        public int InspectionYarnInventoryId { get; set; }
        public int ReasonId { get; set; }
    }
}

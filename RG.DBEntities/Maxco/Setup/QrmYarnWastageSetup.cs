using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class QrmYarnWastageSetup
    {
        public int Id { get; set; }
        public int YwsId { get; set; }
        public int YcId { get; set; }
        public int FabricTypeId { get; set; }
        public int YwsFrom { get; set; }
        public int YwsTo { get; set; }
        public decimal YwsPercentage { get; set; }
    }
}

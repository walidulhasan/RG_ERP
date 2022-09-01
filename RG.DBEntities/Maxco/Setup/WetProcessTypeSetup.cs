using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class WetProcessTypeSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsSprayColorReq { get; set; }
        public bool? IsStitchReq { get; set; }
    }
}

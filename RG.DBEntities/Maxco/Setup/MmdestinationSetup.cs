using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class MmdestinationSetup
    {[Key]
        public int DestinationId { get; set; }
        public string DestinationDesc { get; set; }
    }
}

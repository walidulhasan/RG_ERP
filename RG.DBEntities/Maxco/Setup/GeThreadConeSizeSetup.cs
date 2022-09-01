using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GeThreadConeSizeSetup
    {
        public int Id { get; set; }
        public int ConeSize { get; set; }
        public int? MrpunitId { get; set; }
    }
}

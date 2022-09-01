using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WoStatusSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string UsedFor { get; set; }
    }
}

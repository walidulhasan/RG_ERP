using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class TblDyeingType
    {
        public int Id { get; set; }
        public string DyeingDype { get; set; }
        public int? Serial { get; set; }
        public int? Catagory { get; set; }
    }
}

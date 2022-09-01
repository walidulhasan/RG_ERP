using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcOpOrdermasterPerforma
    {
        public int Id { get; set; }
        public int LopId { get; set; }
        public int LomId { get; set; }
        public int LpoId { get; set; }
        public decimal? OrderValue { get; set; }
        public int? OrderQuantity { get; set; }
    }
}

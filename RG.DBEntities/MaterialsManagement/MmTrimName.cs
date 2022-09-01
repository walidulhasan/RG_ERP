using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmTrimName
    {
        public long TrimId { get; set; }
        public string TrimName { get; set; }
        public int? Status { get; set; }
        public DateTime? Creationdate { get; set; }
    }
}

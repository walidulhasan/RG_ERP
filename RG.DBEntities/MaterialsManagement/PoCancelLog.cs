using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class PoCancelLog
    {
        public int Id { get; set; }
        public int? Poid { get; set; }
        public DateTime? CancellationDate { get; set; }
        public int? PoType { get; set; }
    }
}

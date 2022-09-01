using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblIndWorkorderTerms
    {
        public long Id { get; set; }
        public long? WorkorderId { get; set; }
        public long? Sn { get; set; }
        public string Terms { get; set; }
    }
}

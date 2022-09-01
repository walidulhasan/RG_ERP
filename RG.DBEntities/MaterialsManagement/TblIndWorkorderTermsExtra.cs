using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblIndWorkorderTermsExtra
    {
        public long Id { get; set; }
        public long? WorkorderId { get; set; }
        public long? Sn { get; set; }
        public string TermsExtra { get; set; }
    }
}

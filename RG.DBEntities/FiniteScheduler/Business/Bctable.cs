using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class Bctable
    {
        public string Barcodeno { get; set; }
        public long? Mrpitemcode { get; set; }
        public int? DocumentTypeId { get; set; }
        public long? Serialno { get; set; }
    }
}

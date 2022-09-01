using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblCutoffDetails
    {
        public long? Cutoffid { get; set; }
        public long? Sieid { get; set; }
        public string Sizename { get; set; }
        public long? Sizeqty { get; set; }
    }
}

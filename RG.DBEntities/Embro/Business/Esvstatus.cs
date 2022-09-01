using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class Esvstatus
    {
        public long Esvid { get; set; }
        public decimal ActualAmount { get; set; }
        public decimal Remaining { get; set; }
    }
}

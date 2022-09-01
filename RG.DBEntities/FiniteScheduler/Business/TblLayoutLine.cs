using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblLayoutLine
    {
        public int Id { get; set; }
        public string LineNo { get; set; }
        public string LocationName { get; set; }
        public long? Userid { get; set; }
    }
}

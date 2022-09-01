using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblFam
    {
        public int Id { get; set; }
        public long MachineTypeId { get; set; }
        public string Fam { get; set; }
    }
}

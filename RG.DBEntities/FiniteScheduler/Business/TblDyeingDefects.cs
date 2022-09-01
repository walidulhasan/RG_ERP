using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblDyeingDefects
    {
        public int Id { get; set; }
        public string DefectName { get; set; }
        public int? Sequence { get; set; }
        public int? DefectCategory { get; set; }
    }
}

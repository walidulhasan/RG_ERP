using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TblProfitCenters
    {
        public int Id { get; set; }
        public int ProfitId { get; set; }
        public string ProfitCenter { get; set; }
        public int? ProfitCompanyId { get; set; }
    }
}

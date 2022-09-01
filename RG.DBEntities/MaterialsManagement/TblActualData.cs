using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblActualData
    {
        public long Id { get; set; }
        public int WcId { get; set; }
        public short Tmonth { get; set; }
        public int Tyear { get; set; }
        public decimal Acrm { get; set; }
        public decimal Aclc { get; set; }
        public decimal Acoh { get; set; }
        public decimal Atrm { get; set; }
        public decimal Atlc { get; set; }
        public decimal Atoh { get; set; }
        public bool? Deleted { get; set; }
        public int Wuid { get; set; }
    }
}

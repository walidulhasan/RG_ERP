using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Embro.Setup
{
    public class IncomeStatementGroupMap
    {
        public int ID { get; set; }
        public int SummaryGroupSerial { get; set; }
        public string Particulars { get; set; }
        public int? GroupCategoryID { get; set; }
        public int? COAGroupID { get; set; }
        public string MathActionType { get; set; }
        public int? FromGroupSerial { get; set; }
        public int? ToGroupSerial { get; set; }
        public decimal? CalculationPercent { get; set; }
    }
}

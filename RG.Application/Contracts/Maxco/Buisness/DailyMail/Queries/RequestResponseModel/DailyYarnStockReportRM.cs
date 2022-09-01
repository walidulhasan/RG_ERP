using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class DailyYarnStockReportRM
    {
        public long AttributeInstanceID { get; set; }
        public string CompanyName { get; set; }
        public string LotNo { get; set; }
        public string YarnCount { get; set; }
        public string YarnQuality { get; set; }
        public string YarnComposition { get; set; }
        public decimal OPB { get; set; }
        public decimal OPBValue { get; set; }
        public decimal Rec { get; set; }
        public decimal RecValue { get; set; }
        public decimal Iss { get; set; }
        public decimal IssValue { get; set; }
        
    }
}

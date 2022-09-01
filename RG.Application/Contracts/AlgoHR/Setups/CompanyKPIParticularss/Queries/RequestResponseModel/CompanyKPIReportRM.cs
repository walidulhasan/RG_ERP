using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries.RequestResponseModel
{
    public class CompanyKPIReportRM
    {
        public int ID { get; set; }
        public int Serial { get; set; }
        public string ParticularHead { get; set; }
        public string Particulars { get; set; }
        public int? ParticularValueID { get; set; }
        public decimal? ParticularValue { get; set; }
        public bool IsCalculationParticular { get; set; }
        public int KPIMonth { get; set; }
        public int KPIYear { get; set; }
        public int DecimalUpTo { get; set; }
        public bool AutoCalculation { get; set; }
        public decimal ConversionRate { get; set; }
        public string KPIMonthName { get { return KPIMonth > 0 ? new DateTime(KPIYear, KPIMonth, 1).ToString("MMM") : ""; } }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class MonthlyProductionCostAnalysis
    {
        public int ID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int SalaryAnalysisDivisionID { get; set; }
        public decimal Earning { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

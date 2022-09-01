using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class DivisionOtherCost
    {
        public int OtherCostID { get; set; }
        public int SalaryAnalysisDivisionID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int CostHeadID { get; set; }
        public decimal Cost { get; set; }
       
    }
}

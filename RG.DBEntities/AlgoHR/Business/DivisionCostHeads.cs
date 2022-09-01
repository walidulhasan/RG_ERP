using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class DivisionCostHeads
    {
        public int CostHeadID { get; set; }
        public string CostHead { get; set; }
        public bool HasDetailReport { get; set; }
    }
}

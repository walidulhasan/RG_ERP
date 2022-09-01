using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class Tbl_Holiday
    {
        public int Holiday_ID { get; set; }
        public DateTime Holiday_Date { get; set; }
        public string Holiday_Desc { get; set; }
        public DateTime Holiday_Created { get; set; }
    }
}

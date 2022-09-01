using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.EMS.Setup
{
    public class Tbl_Period
    {
        public long Period_ID { get; set; }
        public string Period_Name { get; set; }
        public DateTime? Period_Start { get; set; }
        public DateTime? Period_End { get; set; }
        public int? Period_Year { get; set; }
        public DateTime? Period_Created { get; set; }
        public Int16? Period_Status { get; set; }
    }
}

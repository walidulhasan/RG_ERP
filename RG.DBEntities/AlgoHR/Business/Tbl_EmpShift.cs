using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class Tbl_EmpShift
    {
        public long? Shift_Emp { get; set; }
        public string Shift_EmpCD { get; set; }
        public int? Shift_Shift { get; set; }
        public DateTime Shift_Date { get; set; }
        public DateTime? Shift_In { get; set; }
        public DateTime? Shift_Out { get; set; }
        public DateTime? Shift_Created { get; set; }
        public bool? Shift_Posted { get; set; }
        public string Shift_Old { get; set; }
        public bool? Shift_Working { get; set; }
        public DateTime? Shift_LunchInMin { get; set; }
        public DateTime? Shift_LunchInMax { get; set; }
    }
}

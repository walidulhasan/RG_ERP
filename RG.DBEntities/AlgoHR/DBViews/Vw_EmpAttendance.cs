using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.DBViews
{
    public class Vw_EmpAttendance
    {
        public long? Serial { get; set; }
        public long? Att_Emp { get; set; }
        public string Att_EmpCd { get; set; }
        public int? Att_Shift { get; set; }
        public string Shift_Name { get; set; }
        public string Shift_Bname { get; set; }
        public short? Att_Status { get; set; }
        public string StatusName { get; set; }
        public DateTime? Att_Date { get; set; }
        public string Att_DateST { get; set; }
        public string DaysName { get; set; }

        public DateTime? Att_ShiftIn { get; set; }
        public string ShiftInTime { get; set; }
        public DateTime? Att_InTime { get; set; }
        public string InTime { get; set; }
        public DateTime? Att_ShiftOut { get; set; }
        public string ShiftOutTime { get; set; }
        public DateTime? Att_OutTime { get; set; }
        public string OutTime { get; set; }
        public decimal? LateMinutes { get; set; }
        public string LateStatus { get; set; }
    }
}

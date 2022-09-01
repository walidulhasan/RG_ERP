using System;

namespace RG.DBEntities.AlgoHR.Business
{
    public class Tbl_EmpAttendance
    {
        public long Att_Emp { get; set; }
        public string Att_EmpCd { get; set; }
        public DateTime Att_Date { get; set; }
        public int Att_Shift { get; set; }
        public DateTime? Att_InTime { get; set; }
        public DateTime? Att_OutTime { get; set; }
        public DateTime? Att_AdjInTime { get; set; }
        public DateTime? Att_AdjOutTime { get; set; }
        public short? Att_Status { get; set; }
        public short? Att_Process { get; set; }
        public DateTime Att_ShiftIn { get; set; }
        public DateTime Att_ShiftOut { get; set; }
        public double? Att_OTHrs { get; set; }
        public double? Att_AdjOtHrs { get; set; }
        public double? Att_AdjOtHrsRound { get; set; }
        public double? Att_OtRate { get; set; }
        public double? Att_IncOTHRs { get; set; }
        public double? Att_AdjInCOTHrs { get; set; }
        public double? Att_IncOTRate { get; set; }
        public bool? Att_Posted { get; set; }
        public double? Att_AdjOtHrs2 { get; set; }
        public string Att_Remarks { get; set; }
        public bool? Att_Adjusted { get; set; }
        public bool? Att_IsLate { get; set; }
        public int? Att_LateMinutes { get; set; }
        public DateTime? Att_GeneratedAt { get; set; }
        public DateTime? Att_LunchIN { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace RG.DBEntities.AlgoHR.Business
{
    public class LateAttendanceWarningLetterMaster
    {
        public LateAttendanceWarningLetterMaster()
        {
            LateAttendanceWarningLetterDetail = new List<LateAttendanceWarningLetterDetail>();
        }
        public int LetterMasterID { get; set; }
        public long EmployeeID { get; set; }
        public int LetterForYear { get; set; }
        public int LetterForMonth { get; set; }
        public DateTime LetterIssueDate { get; set; }
        public virtual List<LateAttendanceWarningLetterDetail> LateAttendanceWarningLetterDetail { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.AlgoHR.Business
{
    public class LateAttendanceWarningLetterDetail
    {
        public int LetterDetailID { get; set; }
        [ForeignKey("LateAttendanceWarningLetterMaster")]
        public int LetterMasterID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime ShiftInTime { get; set; }
        public DateTime AttendanceInTime { get; set; }
        public virtual LateAttendanceWarningLetterMaster LateAttendanceWarningLetterMaster { get; set; }
    }
}

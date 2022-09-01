using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel
{
    public class LateHistoryRM
    {
        public long EmployeeID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime ShiftInTime { get; set; }
        public DateTime AttendanceInTime { get; set; }
        public string AttendanceDateMsg { get; set; }
        public string ShiftInTimeMsg { get; set; }
        public string AttendanceInTimeMsg { get; set; }
        public string LateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel
{
    public class MyAttendanceInfoRM
    {
        public long? Serial { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public string AttendanceDateST { get; set; }
        public string ShiftName { get; set; }
        public string ShiftBName { get; set; }
        public string Status { get; set; }
        public string DaysName { get; set; }
        public string ShiftInDate { get; set; }
        public string ShiftInTime { get; set; }
        public string ShiftOutDate { get; set; }
        public string ShiftOutTime { get; set; }
        public string AttendanceInDate { get; set; }
        public string AttendanceOutDate { get; set; }
        public string AttendanceInTime { get; set; }
        public string AttendanceOutTime { get; set; }
        public decimal? Late { get; set; }

    }
}

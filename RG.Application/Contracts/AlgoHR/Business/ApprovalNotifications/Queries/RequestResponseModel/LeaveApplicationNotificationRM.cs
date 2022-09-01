using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel
{
    public class LeaveApplicationNotificationRM
    {
        public int NotificationID { get; set; }
        public int ApplicationID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveType { get; set; }
        public int LeaveEnjoyed { get; set; }
        public string LeaveFromMsg { get; set; }        
        public string LeaveToMsg { get; set; }
        public string LeaveDate { get; set; }
        public string LeaveDateSort { get; set; }
        public string LeaveCreatedMsg { get; set; }
        public string LeaveReason { get; set; }        
        public bool? LeaveApproved { get; set; }
        public string LeaveAddress { get; set; }
        public string CompanyName { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string Designation { get; set; }
        public int LeaveDays { get; set; }

        public string HolidayType { get; set; }
        public string AttendanceInTime { get; set; }
        public string AttendanceOutTime { get; set; }
        public string ComplimentaryLeaveDate { get; set; }


        public string AttendanceDateStr { get; set; }
        public string AttInTime { get; set; }
        public string AtteOutTime { get; set; }
        /// <summary>
        /// Application wise attendance out time status.
        /// </summary>
        public string ShortLeaveOutTimeStatus { get; set; }

    }
}

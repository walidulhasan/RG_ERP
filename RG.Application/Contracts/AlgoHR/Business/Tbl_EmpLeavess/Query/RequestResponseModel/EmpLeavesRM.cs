using System;

namespace RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel
{
    public class EmpLeavesRM
    {
        public long ID { get; set; }
        public long? Leave_Emp { get; set; }
        public string Leave_EmpCD { get; set; }
        public string Leave_EmpName { get; set; }
        public int? Leave_ID { get; set; }
        public int Leave_TypeID { get; set; }
        public string Leave_Type { get; set; }
        public DateTime? Leave_From { get; set; }
        public string Leave_FromMsg { get { return Leave_From.Value.ToString("dd-MMM-yyyy"); } }
        public DateTime? Leave_To { get; set; }
        public string Leave_ToMsg { get { return IsShortLeave==true? $"({ShortLeaveFromTo})":$"{ Leave_To.Value.ToString("dd-MMM-yyyy")}"; } }
        public DateTime? Leave_Created { get; set; }
        public string Leave_CreatedMsg { get { return Leave_Created.Value.ToString("dd-MMM-yyyy"); } }
        public string Leave_Reason { get; set; }
        public string Leave_User { get; set; }
        public bool? Leave_Approved { get; set; }
        public string Leave_Address { get; set; }
        public string CompanyName { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string Designation { get; set; }
        public int LeaveDays { get; set; }
        public bool IsShortLeave { get; set; }
        public string ShortLeaveFromTo { get; set; }
        public DateTime ShortLeaveFromTime { get; set; }
        public string HolidayType { get; set; }
        public string AttendanceInTime { get; set; }
        public string AttendanceOutTime { get; set; }
        public DateTime? Complimentary_LeaveDate { get; set; }
        public DateTime? AttDate { get; set; }
        public DateTime? AttendanceDateAndOutTime { get; set; }
        //public string AtteOutTime { get; set; }
        public string AttendanceDateStr { get { return AttDate != null ? AttDate.Value.ToString("dd-MMM-yyyy") : ""; } }
        public string ComplimentaryLeaveDate { get { return Complimentary_LeaveDate!=null? Complimentary_LeaveDate.Value.ToString("dd-MMM-yyyy"):""; } }

      
    }
}

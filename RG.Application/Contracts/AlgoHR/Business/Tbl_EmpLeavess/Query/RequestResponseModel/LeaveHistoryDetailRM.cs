using System;

namespace RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel
{
    public class LeaveHistoryDetailRM
    {
        public long LeaveID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string DesignationName { get; set; }
        public string AppointmentDate { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveType { get; set; }
        public DateTime? LeaveFrom { get; set; }
        public string LeaveFromMsg { get { return LeaveFrom.Value.ToString("dd-MMM-yyyy"); } }
        public DateTime? LeaveTo { get; set; }
        public string LeaveToMsg { get { return LeaveTo.Value.ToString("dd-MMM-yyyy"); } }
        public bool? LeaveApproved { get; set; }
        public string LeaveStatus { get { return LeaveApproved == null ? $"Processing(@ {PendingAtApprover} )" : LeaveApproved.Value == true ? "Approved" : "Rejected"; } }
        public string LeaveReason { get; set; }
        public string LeaveAddress { get; set; }
        public int LeaveDays { get; set; }
        public string PendingAtApprover { get; set; }
        public int ApprovalLevel { get; set; }
        public string LeaveTimeFrom { get; set; }
        public string LeaveTimeTo { get; set; }
    }
}

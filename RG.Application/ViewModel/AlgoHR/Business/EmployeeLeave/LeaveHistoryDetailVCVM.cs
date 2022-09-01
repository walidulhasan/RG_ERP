using RG.Application.Common.Mappings;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.EmployeeLeave
{
    public class LeaveHistoryDetailVCVM : IMapFrom<LeaveHistoryDetailRM>
    {
        public long LeaveID { get; set; }
        public long EmployeeID { get; set; }
        public bool ShowEmployeeCode { get; set; } 
        public string EmployeeCode { get; set; }
        public bool ShowEmployeeName { get; set; } 
        public string EmployeeName { get; set; }
        public bool ShowCompanyName { get; set; }
        public string CompanyName { get; set; }
        public bool ShowDivisionName { get; set; } 
        public string DivisionName { get; set; }
        public bool ShowDepartmentName { get; set; } 
        public string DepartmentName { get; set; }
        public bool ShowSectionName { get; set; } 
        public string SectionName { get; set; }
        public bool ShowDesignationName { get; set; }
        public string DesignationName { get; set; }
        public bool ShowAppointmentDate { get; set; }
        public string AppointmentDate { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveType { get; set; }
        public string LeaveFromMsg { get; set; }        
        public string LeaveToMsg { get; set; }       
        public string LeaveStatus { get; set; }
        public string LeaveReason { get; set; }
        public string LeaveAddress { get; set; }
        public int LeaveDays { get; set; }
        public bool? LeaveApproved { get; set; }
        public int ApprovalLevel { get; set; }
        public string LeaveTimeFrom { get; set; }
        public string LeaveTimeTo { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<LeaveHistoryDetailVCVM, LeaveHistoryDetailRM>().ReverseMap();
        }
    }
}

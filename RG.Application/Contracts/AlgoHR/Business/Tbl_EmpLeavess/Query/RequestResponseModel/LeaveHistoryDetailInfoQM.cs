using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel
{
    public class LeaveHistoryDetailInfoQM
    {
        public int CompanyID { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public int SectionID { get; set; }
        public int DesignationID { get; set; }



        public int EmployeeID { get; set; }
        public int LeaveTypeID { get; set; }
        public bool LeaveStatusIndependent { get; set; } = true;
        public bool? LeaveStatus { get; set; }
        public DateTime? SearchDate { get; set; }
        public int? SearchYear { get; set; }

        public bool ShowEmployeeCode { get; set; } = true;
        public bool ShowEmployeeName { get; set; } = true;
        public bool ShowCompanyName { get; set; } = true;
        public bool ShowDivisionName { get; set; } = true;
        public bool ShowDepartmentName { get; set; } = true;
        public bool ShowSectionName { get; set; } = true;
        public bool ShowDesignationName { get; set; } = true;
        public bool ShowAppointmentDate { get; set; } = true;
    }
}

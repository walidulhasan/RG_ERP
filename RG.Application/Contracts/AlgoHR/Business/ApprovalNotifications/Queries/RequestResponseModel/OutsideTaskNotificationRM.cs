using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel
{
    public class OutsideTaskNotificationRM
    {
        public int NotificationID { get; set; }
        public int OutSideTaskID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string TaskDurationType { get; set; }
        public string OutsideTaskDate { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public int EmbroCompanyID { get; set; }       
        public string Company { get; set; }
        public string Division { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public string Department { get; set; }
        public int SectionID { get; set; }
        public string Section { get; set; }
        public int DesignationID { get; set; }
        public string Designation { get; set; }
        public string ApplicantName { get; set; }
        public string Reason { get; set; }
        public string TaskAddress { get; set; }
    }
}

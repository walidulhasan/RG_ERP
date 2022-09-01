using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.DBViews
{
    public class Vw_OutSideTask
    {
        [Key]
        public int OutSideTaskID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string TaskDurationType { get; set; }
       
        public DateTime OutsideTaskDate { get; set; }
        [NotMapped]
        public string OutsideTaskDateMsg { get { return OutsideTaskDate.ToString("dd-MMM-yyyy"); } }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public int? IsApproved { get; set; }
        public string ApprovalStatus { get; set; }
        public int EmbroCompanyID { get; set; }
        public string Cmp_ShortName { get; set; }
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
        public string WaitingForApproval { get; set; }
        public string ViewStatus { get { return ApprovalStatus == "Processing" ? $"{ApprovalStatus}" : ApprovalStatus; } }
        public string Reason { get; set; }
        public string TaskAddress { get; set; }
    }
}


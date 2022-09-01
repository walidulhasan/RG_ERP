using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.AlgoHR.DBViews
{
    public class vw_ERP_EmpShortInfo
    {
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string Emp_Appointment { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public int DivisionID { get; set; }
        public string DivisionName { get; set; }
        public int? HR_CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int? EmbroCompanyID { get; set; }
        public double? Emp_Salary { get; set; }
        public string Emp_Mobile { get; set; }
        public string Emp_MobileN { get; set; }
        public string Office_Email { get; set; }
    }
}

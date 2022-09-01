using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class Employee
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNameUC { get; set; }
        public int? DesignationID { get; set; }
        public int? DepartmentID { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? EmpSectorID { get; set; }
        public int CompanyID { get; set; }
        public int BusinessID { get; set; }
        public int? EmpStatusTypeID { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsRemoved { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

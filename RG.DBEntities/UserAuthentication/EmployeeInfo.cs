using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.UserAuthentication
{
    public class EmployeeInfo
    {
        [Key]
        public int EmployeeID { get; set; }

        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNameUC { get; set; }
        public string DesignationName { get; set; }
        public int? DesignationID { get; set; }
        public string DepartmentName { get; set; }
        public int? DepartmentID { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? EmpSectionID { get; set; }
        public int CompanyID { get; set; }
        public int? BusinessID { get; set; }
        public int? EmpStatusTypeID { get; set; }

        [Column(Order = 95)]
        public bool? IsActive { get; set; }

        [Column(Order = 96)]
        public bool? IsRemoved { get; set; }

        [Column(Order = 97)]
        public DateTime? CreatedDate { get; set; }

        [Column(Order = 98)]
        public int? CreatedBy { get; set; }

        [Column(Order = 99)]
        public DateTime? LastModifiedDate { get; set; }

        [Column(Order = 100)]
        public int? LastModifiedBy { get; set; }
    }
}
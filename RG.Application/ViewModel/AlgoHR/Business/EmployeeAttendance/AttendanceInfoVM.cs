using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.EmployeeAttendance
{
   public class AttendanceInfoVM
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int CompanyID { get; set; }
        public int BusinessFormatID { get; set; }
        public int PayrollEmployeeCategoryID { get; set; }
        public int DisbursementTypeID { get; set; }
        public string NewEmployeeCode { get; set; }
        public string OldEmployeeCode { get; set; }

        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public int SectionID { get; set; }
        public int DesignationID { get; set; }
        public int CadreID { get; set; }
        public int SalaryGradeID { get; set; }
        public string Gender { get; set; }
        public int EmployeeTypeID { get; set; }

        public int EmployeeStatusID { get; set; }
        public int LocationID { get; set; }
        public int SalaryRageFrom { get; set; }
        public int SalaryRageTo { get; set; }

        public int ShiftAssigneID { get; set; }

        public string AttendanceStatus { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLBusinessFormat { get; set; }
        public List<SelectListItem> DDLPayrollEmployeeCategory { get; set; }
        public List<SelectListItem> DDLDisbursementType { get; set; }
        public List<SelectListItem> DDLDivision { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }
        public List<SelectListItem> DDLSection { get; set; }
        public List<SelectListItem> DDLDesignation { get; set; }
        public List<SelectListItem> DDLCadre { get; set; }
        public List<SelectListItem> DDLSalaryGrade { get; set; }
        public List<SelectListItem> DDLGender { get; set; }
        public List<SelectListItem> DDLEmpType { get; set; }
        public List<SelectListItem> DDLStatus { get; set; }
        public List<SelectListItem> DDLLocation { get; set; }
        public List<SelectListItem> DDLShiftAssigne { get; set; }
        public List<SelectListItem> DDLEmployee { get; set; }
        public List<SelectListItem> DDLAttendanceStatus { get; set; }
    }
}

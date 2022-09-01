using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Payroll_Masters.Query.RequestResponseModel
{
    public class SalaryPaySlipRM
    {
        public string CompanyName { get; set; }
        public string CompanyNameBn { get; set; }
        public string DivisionName { get; set; }
        public string DivisionNameBn { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameBn { get; set; }
        public string SectionName { get; set; }
        public string SectionNameBn { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNameBn { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeAlgoCode { get; set; }
        public string DesignationName { get; set; }
        public string DesignationNameBn { get; set; }
        public int EmployeeGrade { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HouseRent { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal FoodAllowance { get; set; }
        public decimal ConveyanceAmount { get; set; }
        public int PresentDays { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal OtHours { get; set; }
        public decimal OtAmount { get; set; }
        public decimal OtRate { get; set; }
        public decimal ComplianceBonus { get; set; }
        public decimal FestivalAllowance { get; set; }
        public decimal DeductionAmount { get; set; }
        public decimal TotalAmountToPay { get { return GrossSalary + OtAmount + ComplianceBonus + FestivalAllowance - DeductionAmount; } }
        public decimal NetSalary { get; set; }
        //public decimal BasicSalary { get; set; }
    }
}

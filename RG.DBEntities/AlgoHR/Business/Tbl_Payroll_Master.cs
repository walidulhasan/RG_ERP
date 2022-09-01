using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class Tbl_Payroll_Master
    {
        [Key]
        public long Payroll_ID { get; set; }
        public long? Payroll_Emp { get; set; }
        public string Payroll_EmpCD { get; set; }
        public DateTime Payroll_From { get; set; }
        public DateTime Payroll_To { get; set; }
        public int? Payroll_Month { get; set; }
        public int? Payroll_Year { get; set; }
        public int? Payroll_Version { get; set; }
        public bool? Payroll_Modified { get; set; }
        public int? Payroll_Status { get; set; }
        public bool? Payroll_Paid { get; set; }
        public DateTime? Payroll_PaidDate { get; set; }
        public bool? Payroll_Bank { get; set; }
        public double? Payroll_Basic { get; set; }
        public double? Payroll_Allowance { get; set; }
        public double? Payroll_Taxable { get; set; }
        public short? Payroll_EmpTotalDays { get; set; }
        public double? Payroll_Present { get; set; }
        public double? Payroll_Absent { get; set; }
        public short? Payroll_OffDay { get; set; }
        public short? Payroll_LWP { get; set; }
        public short? Payroll_LWOP { get; set; }
        public short? Payroll_Holiday { get; set; }
        public double? Payroll_PayDays { get; set; }
        public short? Payroll_TTLDays { get; set; }
        public short? Payroll_Default { get; set; }
        public double? Payroll_WorkedHours { get; set; }
        public double? Payroll_workedHoursAmount { get; set; }
        public double? Payroll_OtHrs { get; set; }
        public double? Payroll_OtAmt { get; set; }
        public double? Payroll_ExtraOtHrs { get; set; }
        public double? Payroll_ExtraOtAmt { get; set; }
        public double? Payroll_AttendanceAllownce { get; set; }
        public double? Payroll_ConductAllowance { get; set; }
        public double? Payroll_ProductionBonus { get; set; }
        public double? Payroll_TotalAllowances { get; set; }
        public double? Payroll_OtherAllowances { get; set; }
        public double? Payroll_GrossSalary { get; set; }
        public double? Payroll_StampDeduction { get; set; }
        public double? Payroll_Deduction { get; set; }
        public double? Payroll_Advance { get; set; }
        public double? Payroll_Loan { get; set; }
        public double? Payroll_StampDeductions { get; set; }
        public double? Payroll_WelfareFund { get; set; }
        public double? Payroll_Tax { get; set; }
        public double? Payroll_NetSalary { get; set; }
        public double? Payroll_BasicSalary { get; set; }
        public double? Payroll_BasicSalary_Earned { get; set; }
        public double? Payroll_HouseRent { get; set; }
        public double? Payroll_HouseRent_Earned { get; set; }
        public double? Payroll_Medical { get; set; }
        public double? Payroll_Medical_Earned { get; set; }
        public double? Payroll_Conveyance { get; set; }
        public double? Payroll_Conveyance_Earned { get; set; }
        public double? Payroll_Food { get; set; }
        public double? Payroll_Food_Earned { get; set; }
        public short? Payroll_RoundOff { get; set; }
        public short? Payroll_Dept { get; set; }
        public short? Payroll_Section { get; set; }
        public short? Payroll_Designation { get; set; }
        public int? payroll_PFValue { get; set; }
        public int? Payroll_EmpCategory { get; set; }
        public double? Payroll_Fines { get; set; }
        public string? Payroll_Phase { get; set; }
        public string? Payroll_Bkash_Bank { get; set; }
        public string? Payroll_calculation { get; set; }
        public string? Payroll_disburse { get; set; }
        public double? Payroll_arrear { get; set; }
    }
}

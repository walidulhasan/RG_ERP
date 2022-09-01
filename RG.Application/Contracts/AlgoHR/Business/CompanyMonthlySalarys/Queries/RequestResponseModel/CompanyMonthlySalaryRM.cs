using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CompanyMonthlySalarys.Queries.RequestResponseModel
{
    public class CompanyMonthlySalaryRM
    {
        public int ID { get; set; }
        public int SalaryMonth { get; set; }
        public string SalaryMonthName { get; set; }
        public int SalaryYear { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int DivisionID { get; set; }
        public string DivisionName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public int NoOfEmployee { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal PaidSalary { get; set; }
        public decimal GeneralOT { get; set; }
        public decimal ExtOT { get; set; }
        public decimal MobileInternetAllowance { get; set; }
        public decimal FoodTransportAllowance { get; set; }
        public decimal CarAllowance { get; set; }
        public decimal FridayAllowance { get; set; }
        public decimal ProductionBonus { get; set; }
        public decimal DoubleMachineBonous { get; set; }
        public decimal EarnLeave { get; set; }
        public decimal MaternityLeave { get; set; }
        public decimal ServiceBenefit { get; set; }
        public decimal HolidayAllowance { get; set; }
        public decimal ArrearAllowance { get; set; }
        public decimal ExtraAllowance { get; set; }      
        public decimal TotalSalary { get { return ( PaidSalary + GeneralOT + ExtOT); } }
        public decimal TotalAllowance { get { return (MobileInternetAllowance + FoodTransportAllowance + CarAllowance + FridayAllowance + ProductionBonus + DoubleMachineBonous + EarnLeave + MaternityLeave + ServiceBenefit + HolidayAllowance + ArrearAllowance + ExtraAllowance); } }
        public decimal TotalPaymentRequired { get { return (TotalSalary + TotalAllowance); } }
    }
}

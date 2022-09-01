using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Payroll_Masters.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class Tbl_Payroll_MasterRepository : GenericRepository<Tbl_Payroll_Master>, ITbl_Payroll_MasterRepository
    {
        private AlgoHRDBContext dbCon;
        public Tbl_Payroll_MasterRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<SalaryPaySlipRM> GetSalaryPaySlipInfo(int employeeID, int month, int year, CancellationToken cancellationToken)
        {
           
            var query = from e in dbCon.Tbl_Emp
                        join d in dbCon.Tbl_Dept on e.Emp_Dept equals d.Dept_ID
                        join dv in dbCon.Tbl_Division on d.Dept_Division equals dv.Division_ID
                        join c in dbCon.Tbl_Company on dv.Division_Company equals c.Cmp_ID
                        join s in dbCon.Tbl_Section on e.Emp_Section equals s.Section_Id
                        join dj in dbCon.Tbl_Designation on e.Emp_Designation.Value equals dj.Designation_Id
                        join pm in dbCon.Tbl_Payroll_Master
                               on new { EmployeeCode = e.Emp_ID, Year = year, Month = month } equals new { EmployeeCode = pm.Payroll_Emp.Value, Year = pm.Payroll_From.Year, Month = pm.Payroll_From.Month }
                               into map
                        from pmlj in map.DefaultIfEmpty()
                        where e.Emp_ID == employeeID
                        select new SalaryPaySlipRM() {
                            EmployeeName = e.Emp_Name,
                            EmployeeNameBn = e.Emp_Bname,
                            EmployeeCode = e.Emp_Cd,
                            EmployeeAlgoCode = e.Emp_oldNo,
                            CompanyName = c.Cmp_Name,
                            CompanyNameBn = c.BanglaCName,
                            DivisionName = dv.Division_Name,
                            DivisionNameBn = dv.Division_BName,
                            DepartmentName = d.Dept_Name,
                            DepartmentNameBn = d.Dept_BName,
                            SectionName = s.Section_Name,
                            SectionNameBn = s.Section_BName,                            
                            DesignationName = dj.Designation_Name,
                            DesignationNameBn = dj.Designation_Bname,
                            EmployeeGrade = dj.Designation_Grade.Value,
                            BasicSalary = pmlj== null ? 0 : Convert.ToDecimal(pmlj.Payroll_BasicSalary),
                            HouseRent = pmlj == null ? 0 : Convert.ToDecimal(pmlj.Payroll_HouseRent),
                            MedicalAllowance = pmlj == null ? 0 : Convert.ToDecimal(pmlj.Payroll_Medical),
                            FoodAllowance = pmlj == null ? 0 : Convert.ToDecimal(pmlj.Payroll_Food),
                            ConveyanceAmount = pmlj == null ? 0 : Convert.ToDecimal(pmlj.Payroll_Conveyance),
                            PresentDays = pmlj == null ? 0 :Convert.ToInt32(pmlj.Payroll_PayDays),
                            GrossSalary = pmlj == null ? 0 : Convert.ToDecimal(pmlj.Payroll_BasicSalary_Earned + pmlj.Payroll_HouseRent_Earned+ pmlj.Payroll_Medical_Earned+ pmlj.Payroll_Conveyance_Earned+ pmlj.Payroll_Food_Earned),
                            OtHours = pmlj == null ? 0 : Convert.ToDecimal(pmlj.Payroll_OtHrs),
                            OtAmount = pmlj == null ? 0 : Convert.ToDecimal(pmlj.Payroll_OtAmt),
                            OtRate = Convert.ToDecimal(pmlj == null ? 0 : (pmlj.Payroll_OtHrs > 0 ? pmlj.Payroll_OtAmt / pmlj.Payroll_OtHrs : 0)),
                            ComplianceBonus = pmlj == null ? 0 : Convert.ToDecimal(pmlj.Payroll_AttendanceAllownce),
                            FestivalAllowance = pmlj == null ? 0 : Convert.ToDecimal(e.FestivalAllowance),
                            DeductionAmount = pmlj == null ? 0 : Convert.ToDecimal(pmlj.Payroll_Deduction),
                            NetSalary = pmlj == null ? 0 : Convert.ToDecimal(pmlj.Payroll_NetSalary)

                        };
                var qry = query.ToQueryString();
            var data = await query.FirstOrDefaultAsync(cancellationToken);
            return data;
        }
    }
}

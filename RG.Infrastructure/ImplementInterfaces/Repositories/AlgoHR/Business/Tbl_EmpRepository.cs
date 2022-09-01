using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
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
    public class Tbl_EmpRepository : GenericRepository<Tbl_Emp>, ITbl_EmpRepository
    {
        private readonly AlgoHRDBContext _dbCon;
        public Tbl_EmpRepository(AlgoHRDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<List<EmployeeBreakDownRM>> DDLHREmployeeLookup(List<int> CompanyID, List<int> officeDivisionID, List<int> departmentID, List<int> sectionID, List<int> designationID, string Predict = null, CancellationToken cancalletionToken = default)
        {
            var query = from emp in _dbCon.Tbl_Emp
                        join dep in _dbCon.Tbl_Dept on emp.Emp_Dept equals dep.Dept_ID
                        join div in _dbCon.Tbl_Division on dep.Dept_Division equals div.Division_ID
                        join sec in _dbCon.Tbl_Section on emp.Emp_Section equals sec.Section_Id
                        join com in _dbCon.Tbl_Company on div.Division_Company equals com.Cmp_ID
                        where emp.Emp_Active == true
                        select new
                        {
                            EmployeeID = emp.Emp_ID,
                            EMPCode = emp.Emp_Cd.Trim(),
                            EmployeeName = emp.Emp_Name,
                            Gender = emp.Emp_Gender,
                            CompanyID = com.EmbroCompanyID,
                            DivisionID = div.Division_ID,
                            DepartmentID = dep.Dept_ID,
                            DepartmentName = dep.Dept_Name,
                            SectionID = sec.Section_Id,
                            SectionName = sec.Section_Name,
                            LocationID = sec.Section_Location ?? 0,
                            DesignationID = emp.Emp_Designation ?? 0,
                            EmployeeTypeID = emp.emp_type ?? 1,
                            ActivStatus = emp.Emp_Active ?? true,
                        };


            if (CompanyID.Count > 0)
            {
                query = query.Where(c => CompanyID.Contains(c.CompanyID));
            }

            if (officeDivisionID != null && officeDivisionID.Count > 0)
            {
                query = query.Where(c => officeDivisionID.Contains(c.DivisionID));
            }

            if (departmentID != null && departmentID.Count > 0)
            {
                query = query.Where(c => departmentID.Contains(c.DepartmentID));
            }

            if (sectionID != null && sectionID.Count > 0)
            {
                query = query.Where(c => sectionID.Contains(c.SectionID));
            }



            if (designationID != null && designationID.Count > 0)
            {
                query = query.Where(c => designationID.Contains(c.DesignationID));
            }


            if (!string.IsNullOrEmpty(Predict))
            {
                query = query.Where(b => b.EMPCode.Contains(Predict) || b.EmployeeName.StartsWith(Predict));
            }

            var group = await query
                            .Select(g => $"{g.DepartmentName}-{g.SectionName}")
                            .Distinct()
                            .Select(gn => new SelectListGroup() { Name = gn })
                            .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancalletionToken);
            var dataValue = await query
                            .Select(s => new EmployeeBreakDownRM()
                            {
                                CompanyID = s.CompanyID,
                                DivisionID = s.DivisionID,
                                DepartmentID = s.DepartmentID,
                                SectionID = s.SectionID,
                                Name = $"{s.EMPCode} - {s.EmployeeName}",
                                ID = Convert.ToInt32(s.EmployeeID),
                                DesignationID = s.DesignationID,
                                Group = group[$"{s.DepartmentName}-{s.SectionName}"]
                            }).ToListAsync(cancalletionToken);
            return dataValue;

        }

        public async Task<List<SelectListItem>> GetDDLEmployeeByAdvanceFilter(EmployeeDDLAdvanceFilterQM filterQM, string DPValue = "ID", CancellationToken cancellationToken = default)
        {

            if (DPValue == null && (DPValue != "ID" || DPValue != "Code"))
            {
                DPValue = "ID";
            }

            var query = from emp in _dbCon.Tbl_Emp
                        join dep in _dbCon.Tbl_Dept on emp.Emp_Dept equals dep.Dept_ID
                        join div in _dbCon.Tbl_Division on dep.Dept_Division equals div.Division_ID
                        join sec in _dbCon.Tbl_Section on emp.Emp_Section equals sec.Section_Id
                        join com in _dbCon.Tbl_Company on div.Division_Company equals com.Cmp_ID
                        select new
                        {
                            EmployeeID = emp.Emp_ID,
                            EMPCode = emp.Emp_Cd.Trim(),
                            EmployeeName = emp.Emp_Name,
                            Gender = emp.Emp_Gender,
                            CompanyID = com.EmbroCompanyID,
                            DivisionID = div.Division_ID,
                            DepartmentID = dep.Dept_ID,
                            DepartmentName = dep.Dept_Name,
                            SectionID = sec.Section_Id,
                            SectionName = sec.Section_Name,
                            LocationID = sec.Section_Location ?? 0,
                            DesignationID = emp.Emp_Designation ?? 0,
                            EmployeeTypeID = emp.emp_type ?? 1,
                            ActivStatus = emp.Emp_Active ?? true,
                        };
            if (filterQM.ActiveStatus.HasValue)
            {
                query = query.Where(b => b.ActivStatus == filterQM.ActiveStatus.Value);
            }

            if (filterQM.Companys != null && filterQM.Companys.Count > 0)
            {
                query = query.Where(c => filterQM.Companys.Contains(c.CompanyID));
            }

            if (filterQM.Divisions != null && filterQM.Divisions.Count > 0)
            {
                query = query.Where(c => filterQM.Divisions.Contains(c.DivisionID));
            }

            if (filterQM.Departments != null && filterQM.Departments.Count > 0)
            {
                query = query.Where(c => filterQM.Departments.Contains(c.DepartmentID));
            }

            if (filterQM.Sections != null && filterQM.Sections.Count > 0)
            {
                query = query.Where(c => filterQM.Sections.Contains(c.SectionID));
            }

            if (filterQM.Locations != null && filterQM.Locations.Count > 0)
            {
                query = query.Where(c => filterQM.Locations.Contains(c.LocationID));
            }

            if (filterQM.Designation != null && filterQM.Designation.Count > 0)
            {
                query = query.Where(c => filterQM.Designation.Contains(c.DesignationID));
            }

            if (filterQM.Genders != null)
            {
                query = query.Where(c => c.Gender == c.Gender);
            }

            if (filterQM.Predict != null)
            {
                query = query.Where(b => b.EMPCode.Contains(filterQM.Predict) || b.EmployeeName.StartsWith(filterQM.Predict));
            }

            var group = await query
                            .Select(g => $"{g.DepartmentName}-{g.SectionName}")
                            .Distinct()
                            .Select(gn => new SelectListGroup() { Name = gn })
                            .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancellationToken);
            var dataValue = await query
                            .Select(s => new SelectListItem()
                            {
                                Text = $"{s.EMPCode} - {s.EmployeeName}",
                                Value = DPValue == "ID" ? s.EmployeeID.ToString() : s.EMPCode,
                                Group = group[$"{s.DepartmentName}-{s.SectionName}"]
                            }).ToListAsync(cancellationToken);
            return dataValue;

        }

        public async Task<string> GetEmployeeNameConcate(string EmployeeCodeList, CancellationToken cancellationToken)
        {
            StringBuilder sb = new StringBuilder();
            var empArray = EmployeeCodeList.Split(',', StringSplitOptions.RemoveEmptyEntries);


            int[] intEmpArray = new int[empArray.Length];
            for (var ec = 0; ec < empArray.Length; ec++)
            {
                if (empArray[ec].Length > 0 && !string.IsNullOrWhiteSpace(empArray[ec]))
                {
                    if (empArray[ec].Length < 7)
                    {
                        intEmpArray[ec] = Convert.ToInt32(empArray[ec].Trim());
                    }

                }

            }

            var dbEmp = await _dbCon.Tbl_Emp.Where(b => intEmpArray.Contains(Convert.ToInt32(b.Emp_Cd))).Select(b => b.Emp_Name).ToListAsync(cancellationToken);
            foreach (var d in dbEmp)
            {
                if (sb.Length > 0)
                {
                    sb.Append(",");
                }
                sb.Append(d);
            }

            return sb.ToString();

        }


        public async Task<List<SelectListItem>> MachineMaintenanceEmployees()
        {
            var data = await _dbCon.Tbl_Emp.Select(x => new SelectListItem
            {
                Text = x.Emp_Name.Trim(),
                Value = x.Emp_Cd.Trim()
            }).ToListAsync();
            return data;
        }
        public async Task<EmployeePersonalInfoRM> GetEmployeePersonalInfo(string EmployeeCode, CancellationToken cancellationToken)
        {
            var data = await _dbCon.Tbl_Emp
                       .Where(x => x.Emp_Cd.Trim() == EmployeeCode.Trim())
                       .Select(x => new EmployeePersonalInfoRM
                       {
                           Emp_ID = x.Emp_ID,
                           Emp_Cd = x.Emp_Cd.Trim(),
                           Emp_oldNo = x.Emp_oldNo.Trim(),
                           Emp_Name = x.Emp_Name.Trim(),
                           Emp_Father = x.Emp_Father.Trim(),
                           Emp_MotherName = x.Emp_MotherName.Trim(),
                           Emp_DOB = x.Emp_DOB,
                           Emp_Appointment = x.Emp_Appointment,
                           Emp_Confirmation = x.Emp_Confirmation,
                           emp_type = x.emp_type,
                           Emp_Religion = x.Emp_Religion,
                           Emp_SSN = x.Emp_SSN,
                           Emp_Fname=x.Emp_Fname,
                           Emp_Mname=x.Emp_Mname,
                           Emp_Lname=x.Emp_Lname,
                           Emp_Gender=x.Emp_Gender.Trim()
                       }).FirstAsync(cancellationToken);
            return data;
        }

        public async Task<EmployeeAddressInfoRM> GetEmployeeAddressInfo(string EmployeeCode, CancellationToken cancellationToken)
        {
            var data = await _dbCon.Tbl_Emp
                       .Where(x => x.Emp_Cd.Trim() == EmployeeCode.Trim())
                       .Select(x => new EmployeeAddressInfoRM
                       {
                           Emp_ID = x.Emp_ID,
                           Emp_Country1 = x.Emp_Country1,
                           Emp_Country2 = x.Emp_Country2,
                           Emp_State1 = x.Emp_State1,
                           Emp_State2 = x.Emp_State2,
                           Emp_City1 = x.Emp_City1,
                           Emp_City2 = x.Emp_City2,
                           Emp_Address1 = x.Emp_Address1,
                           Emp_Address2 = x.Emp_Address2,
                           Emp_Zip1 = x.Emp_Zip1,
                           Emp_Zip2 = x.Emp_Zip2,

                       }).FirstAsync(cancellationToken);
            return data;
        }
    }
}

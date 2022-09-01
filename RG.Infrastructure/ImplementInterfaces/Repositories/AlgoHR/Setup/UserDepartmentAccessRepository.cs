using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class UserDepartmentAccessRepository : GenericRepository<UserDepartmentAccess>, IUserDepartmentAccessRepository
    {
        private readonly AlgoHRDBContext _dbCon;
        public UserDepartmentAccessRepository(AlgoHRDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<SelectListItem>> DDLUserCompany(int UserID, bool IsAll = false, CancellationToken cancellationToken = default)
        {

            if (IsAll == true)
            {
                var query = from com in _dbCon.Tbl_Company
                            join uc in _dbCon.UserDepartmentAccess on new { p1 = UserID, p2 = com.EmbroCompanyID } equals new { p1 = uc.CA_UserID, p2 = uc.Embro_CompanyID } into com_us
                            from _com_us in com_us.DefaultIfEmpty()
                            select new SelectListItem()
                            {
                                Text = com.Cmp_Name,
                                Value = com.EmbroCompanyID.ToString(),
                                /*Selected = (_com_us != null && com.EmbroCompanyID == _com_us.Embro_CompanyID) ? true : false*/
                            };
                return await query.Distinct().ToListAsync(cancellationToken); ;
            }
            else
            {
                var query = from com in _dbCon.Tbl_Company
                            join uc in _dbCon.UserDepartmentAccess on new { p1 = UserID, p2 = com.EmbroCompanyID } equals new { p1 = uc.CA_UserID, p2 = uc.Embro_CompanyID }
                            select new SelectListItem()
                            {
                                Text = com.Cmp_Name,
                                Value = com.EmbroCompanyID.ToString(),
                                //Selected = true,
                            };
                return await query.Distinct().ToListAsync(cancellationToken); ;
            }


        }

        public async Task<List<SelectListItem>> DDLUserDepartment(int UserID, List<int> CompanyID, List<int> DivisionID, bool IsAll = false, string Predict = null, CancellationToken cancellationToken = default)
        {
            //EmployeeToSectionRM
            if (IsAll == false)
            {
                var query = from dep in _dbCon.Tbl_Dept
                            join div in _dbCon.Tbl_Division on dep.Dept_Division equals div.Division_ID
                            join comp in _dbCon.Tbl_Company on div.Division_Company equals comp.Cmp_ID
                            join _udep in _dbCon.UserDepartmentAccess on new { p1 = UserID, p2 = dep.Dept_ID } equals new { p1 = _udep.CA_UserID, p2 = _udep.DepartmentID }
                            where (CompanyID.Count == 0 || CompanyID.Contains(comp.EmbroCompanyID))
                               && (DivisionID.Count == 0 || DivisionID.Contains(div.Division_ID))
                               && (Predict == null || dep.Dept_Name.Contains(Predict))
                            select new
                            {
                                CompanyShort = comp.Cmp_ShortName,
                                Division = div.Division_Name,
                                Department = dep.Dept_Name,
                                DepartmentID = dep.Dept_ID,
                                SelectedDepartmentID = _udep.DepartmentID
                            };

                var group = await query
                           .Select(g => $"{g.CompanyShort}-{g.Division}")
                           .Distinct()
                           .Select(gn => new SelectListGroup() { Name = gn })
                           .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancellationToken);

                var dataValue = await query
                                .Select(s => new SelectListItem()
                                {
                                    Text = s.Department,
                                    Value = s.DepartmentID.ToString(),
                                    //Selected = true,
                                    Group = group[$"{s.CompanyShort}-{s.Division}"]

                                }).Distinct().ToListAsync(cancellationToken);
                return dataValue;



            }
            else
            {
                var query = from dep in _dbCon.Tbl_Dept
                            join div in _dbCon.Tbl_Division on dep.Dept_Division equals div.Division_ID
                            join comp in _dbCon.Tbl_Company on div.Division_Company equals comp.Cmp_ID
                            join _udep in _dbCon.UserDepartmentAccess on new { p1 = UserID, p2 = dep.Dept_ID } equals new { p1 = _udep.CA_UserID, p2 = _udep.DepartmentID } into _userDep
                            from userDep in _userDep.DefaultIfEmpty()
                            where (CompanyID.Count == 0 || CompanyID.Contains(comp.EmbroCompanyID))
                               && (DivisionID.Count == 0 || DivisionID.Contains(div.Division_ID))
                               && (Predict == null || dep.Dept_Name.Contains(Predict))
                            select new
                            {
                                CompanyShort = comp.Cmp_ShortName,
                                Division = div.Division_Name,
                                Department = dep.Dept_Name,
                                DepartmentID = dep.Dept_ID,
                                SelectedDepartmentID = userDep == null ? 0 : userDep.DepartmentID
                            };

                var group = await query
                           .Select(g => $"{g.CompanyShort}-{g.Division}")
                           .Distinct()
                           .Select(gn => new SelectListGroup() { Name = gn })
                           .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancellationToken);

                var dataValue = await query
                                .Select(s => new SelectListItem()
                                {
                                    Text = s.Department,
                                    Value = s.DepartmentID.ToString(),
                                    // Selected = s.DepartmentID == s.SelectedDepartmentID ? true : false,
                                    Group = group[$"{s.CompanyShort}-{s.Division}"]
                                }).Distinct().ToListAsync(cancellationToken);
                return dataValue;

            }
        }

        public async Task<List<SelectListItem>> DDLUserDivision(int UserID, List<int> CompanyID, bool IsAll = false, string Predict = null, CancellationToken cancellationToken = default)
        {

            //EmployeeToSectionRM
            if (IsAll == false)
            {
                var query = from div in _dbCon.Tbl_Division
                            join comp in _dbCon.Tbl_Company on div.Division_Company equals comp.Cmp_ID
                            join _udiv in _dbCon.UserDepartmentAccess on new { p1 = UserID, p2 = div.Division_ID } equals new { p1 = _udiv.CA_UserID, p2 = _udiv.DivisionID }
                            where (CompanyID.Count == 0 || CompanyID.Contains(comp.EmbroCompanyID))
                                  && (Predict == null || div.Division_Name.Contains(Predict))
                            select new SelectListItem()
                            {
                                Text = $"{comp.Cmp_ShortName} - {div.Division_Name}",
                                Value = div.Division_ID.ToString(),
                                //   Selected = true
                            };
                return await query.Distinct().ToListAsync(cancellationToken);
            }
            else
            {
                var query = from div in _dbCon.Tbl_Division
                            join comp in _dbCon.Tbl_Company on div.Division_Company equals comp.Cmp_ID
                            join _udiv in _dbCon.UserDepartmentAccess on new { p1 = UserID, p2 = div.Division_ID } equals new { p1 = _udiv.CA_UserID, p2 = _udiv.DivisionID } into user_Div
                            from _userDiv in user_Div.DefaultIfEmpty()
                            where (CompanyID.Count == 0 || CompanyID.Contains(comp.EmbroCompanyID))
                                   && (Predict == null || div.Division_Name.Contains(Predict))
                            select new SelectListItem()
                            {
                                Text = $"{comp.Cmp_ShortName} - {div.Division_Name}",
                                Value = div.Division_ID.ToString(),
                                // Selected = (_userDiv != null && _userDiv.DivisionID == div.Division_ID) ? true : false
                            };
                return await query.Distinct().ToListAsync(cancellationToken);
            }


        }

        public async Task<List<SelectListItem>> DDLUserSection(int UserID, List<int> CompanyID, List<int> DivisionID, List<int> DepartmentID, bool IsAll = false, string Predict = null, CancellationToken cancellationToken = default)
        {

            //EmployeeToSectionRM
            if (IsAll == false)
            {
                var query = from sec in _dbCon.Tbl_Section
                            join dep in _dbCon.Tbl_Dept on sec.Section_Dept equals dep.Dept_ID
                            join div in _dbCon.Tbl_Division on dep.Dept_Division equals div.Division_ID
                            join comp in _dbCon.Tbl_Company on div.Division_Company equals comp.Cmp_ID
                            join _udep in _dbCon.UserDepartmentAccess on new { p1 = UserID, p2 = sec.Section_Id } equals new { p1 = _udep.CA_UserID, p2 = _udep.SectionID }
                            where (CompanyID.Count == 0 || CompanyID.Contains(comp.EmbroCompanyID))
                               && (DivisionID.Count == 0 || DivisionID.Contains(div.Division_ID))
                               && (DepartmentID.Count == 0 || DepartmentID.Contains(dep.Dept_ID))
                               && (Predict == null || sec.Section_Name.Contains(Predict))
                            select new
                            {
                                CompanyShort = comp.Cmp_ShortName,
                                Division = div.Division_Name,
                                Section = sec.Section_Name,
                                SectionID = sec.Section_Id,
                                SelectedSectionID = _udep.SectionID
                            };

                var group = await query
                           .Select(g => $"{g.CompanyShort}-{g.Division}")
                           .Distinct()
                           .Select(gn => new SelectListGroup() { Name = gn })
                           .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancellationToken);

                var dataValue = await query
                                .Select(s => new SelectListItem()
                                {
                                    Text = s.Section,
                                    Value = s.SectionID.ToString(),
                                    Group = group[$"{s.CompanyShort}-{s.Division}"]

                                }).Distinct().ToListAsync(cancellationToken);
                return dataValue;



            }
            else
            {
                var query = from sec in _dbCon.Tbl_Section
                            join dep in _dbCon.Tbl_Dept on sec.Section_Dept equals dep.Dept_ID
                            join div in _dbCon.Tbl_Division on dep.Dept_Division equals div.Division_ID
                            join comp in _dbCon.Tbl_Company on div.Division_Company equals comp.Cmp_ID
                            join _udep in _dbCon.UserDepartmentAccess on new { p1 = UserID, p2 = sec.Section_Id } equals new { p1 = _udep.CA_UserID, p2 = _udep.SectionID } into _userDep
                            from userDep in _userDep.DefaultIfEmpty()
                            where (CompanyID.Count == 0 || CompanyID.Contains(comp.EmbroCompanyID))
                               && (DivisionID.Count == 0 || DivisionID.Contains(div.Division_ID))
                               && (DepartmentID.Count == 0 || DepartmentID.Contains(dep.Dept_ID))
                              && (Predict == null || sec.Section_Name.Contains(Predict))
                            select new
                            {
                                CompanyShort = comp.Cmp_ShortName,
                                Division = div.Division_Name,
                                Section = sec.Section_Name,
                                SectionID = sec.Section_Id,
                                SelectedSectionID = userDep == null ? 0 : userDep.SectionID
                            };

                var group = await query
                           .Select(g => $"{g.CompanyShort}-{g.Division}")
                           .Distinct()
                           .Select(gn => new SelectListGroup() { Name = gn })
                           .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancellationToken);

                var dataValue = await query
                                .Select(s => new SelectListItem()
                                {
                                    Text = s.Section,
                                    Value = s.SectionID.ToString(),
                                    //Selected = s.SectionID == s.SelectedSectionID ? true : false,
                                    Group = group[$"{s.CompanyShort}-{s.Division}"]
                                }).Distinct().ToListAsync(cancellationToken);
                return dataValue;

            }
        }

        public async Task<List<SelectListItem>> DDLUserSectionEmployee(int UserID, List<int> CompanyID, List<int> DivisionID, List<int> DepartmentID, List<int> SectionID
            , List<int> Designations, List<int> Locations, int? EmployeeTypes = null, string Gender = null, bool? ActiveStatus = null
            , string Predict = null, bool IsAll = false, CancellationToken cancellationToken = default)
        {

            //EmployeeToSectionRM
            if (IsAll == false)
            {
                var query = from emp in _dbCon.Tbl_Emp
                            join sec in _dbCon.Tbl_Section on emp.Emp_Section equals sec.Section_Id
                            join dep in _dbCon.Tbl_Dept on sec.Section_Dept equals dep.Dept_ID
                            join div in _dbCon.Tbl_Division on dep.Dept_Division equals div.Division_ID
                            join comp in _dbCon.Tbl_Company on div.Division_Company equals comp.Cmp_ID
                            join _udep in _dbCon.UserDepartmentAccess on new { p1 = UserID, p2 = sec.Section_Id } equals new { p1 = _udep.CA_UserID, p2 = _udep.SectionID }
                            where emp.Emp_Active == true && (CompanyID.Count == 0 || CompanyID.Contains(comp.EmbroCompanyID))
                               && (DivisionID.Count == 0 || DivisionID.Contains(div.Division_ID))
                               && (DepartmentID.Count == 0 || DepartmentID.Contains(dep.Dept_ID))
                               && (SectionID.Count == 0 || SectionID.Contains(sec.Section_Id))
                               && (Designations.Count == 0 || Designations.Contains(emp.Emp_Designation.Value))
                               && (Locations.Count == 0 || Locations.Contains(sec.Section_Location.Value))
                               && (EmployeeTypes.HasValue == false || (EmployeeTypes.Value > 0 && emp.emp_type == EmployeeTypes))
                               && (Gender == null || (emp.Emp_Gender == Gender))
                               && (Predict == null || emp.Emp_Cd.Contains(Predict) || emp.Emp_Name.Contains(Predict))
                            select new
                            {
                                CompanyShort = comp.Cmp_ShortName,
                                Division = div.Division_Name,
                                Department = dep.Dept_Name,
                                Section = sec.Section_Name,
                                SectionID = sec.Section_Id,
                                SelectedSectionID = _udep.SectionID,
                                EmpName = emp.Emp_Name,
                                EmpCode = emp.Emp_Cd,
                                EmpID = emp.Emp_ID
                            };
                var _q = query.ToQueryString();
                var group = await query
                           .Select(g => $"{g.Department} - {g.Section}")
                           .Distinct()
                           .Select(gn => new SelectListGroup() { Name = gn })
                           .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancellationToken);

                var dataValue = await query
                                .Select(s => new SelectListItem()
                                {
                                    Text = $"{s.EmpCode} - {s.EmpName}",
                                    Value = s.EmpID.ToString(),
                                    Group = group[$"{s.Department} - {s.Section}"]
                                }).ToListAsync(cancellationToken);
                return dataValue;
            }
            else
            {
                var query = from emp in _dbCon.Tbl_Emp
                            join sec in _dbCon.Tbl_Section on emp.Emp_Section equals sec.Section_Id
                            join dep in _dbCon.Tbl_Dept on sec.Section_Dept equals dep.Dept_ID
                            join div in _dbCon.Tbl_Division on dep.Dept_Division equals div.Division_ID
                            join comp in _dbCon.Tbl_Company on div.Division_Company equals comp.Cmp_ID
                            join _udep in _dbCon.UserDepartmentAccess on new { p1 = UserID, p2 = sec.Section_Id } equals new { p1 = _udep.CA_UserID, p2 = _udep.SectionID } into _userDep
                            from userDep in _userDep.DefaultIfEmpty()
                            where emp.Emp_Active == true && (CompanyID.Count == 0 || CompanyID.Contains(comp.EmbroCompanyID))
                               && (DivisionID.Count == 0 || DivisionID.Contains(div.Division_ID))
                               && (DepartmentID.Count == 0 || DepartmentID.Contains(dep.Dept_ID))
                                                 && (SectionID.Count == 0 || SectionID.Contains(sec.Section_Id))
                               && (Designations.Count == 0 || Designations.Contains(emp.Emp_Designation.Value))
                               && (Locations.Count == 0 || Locations.Contains(sec.Section_Location.Value))
                               && (EmployeeTypes.HasValue == false || (EmployeeTypes.Value > 0 && emp.emp_type == EmployeeTypes))
                               && (Gender == null || (emp.Emp_Gender == Gender))
                               && (Predict == null || emp.Emp_Cd.Contains(Predict) || emp.Emp_Name.Contains(Predict))
                                 && (Predict == null || emp.Emp_Cd.Contains(Predict) || emp.Emp_Name.Contains(Predict))
                            select new
                            {
                                CompanyShort = comp.Cmp_ShortName,
                                Division = div.Division_Name,
                                Department = dep.Dept_Name,
                                Section = sec.Section_Name,
                                SectionID = sec.Section_Id,
                                SelectedSectionID = userDep == null ? 0 : userDep.SectionID,
                                EmpName = emp.Emp_Name,
                                EmpCode = emp.Emp_Cd,
                                EmpID = emp.Emp_ID
                            };

                var group = await query
                           .Select(g => $"{g.Department}-{g.Section}")
                           .Distinct()
                           .Select(gn => new SelectListGroup() { Name = gn })
                           .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancellationToken);

                var dataValue = await query
                                .Select(s => new SelectListItem()
                                {
                                    Text = $"{s.EmpCode} - {s.EmpName}",
                                    Value = s.EmpID.ToString(),
                                    Group = group[$"{s.Department}-{s.Section}"]
                                }).ToListAsync(cancellationToken);
                return dataValue;

            }
        }

        public IQueryable<EmployeeToSectionRM> GetUserDepartmentAccessList(int UserID = 0)
        {
            var dataQuery = from com in _dbCon.Tbl_Company
                            join div in _dbCon.Tbl_Division on com.Cmp_ID equals div.Division_Company
                            join dep in _dbCon.Tbl_Dept on div.Division_ID equals dep.Dept_Division
                            join sec in _dbCon.Tbl_Section on dep.Dept_ID equals sec.Section_Dept
                            join usds in _dbCon.UserDepartmentAccess on new { p1 = sec.Section_Id, p2 = UserID }
                                                                equals new { p1 = usds.SectionID, p2 = usds.CA_UserID } into _user_Sec
                            from userSec in _user_Sec.DefaultIfEmpty()
                            select new EmployeeToSectionRM
                            {
                                ID = userSec == null ? 0 : userSec.ID,
                                CompanyID = com.EmbroCompanyID,
                                CompanyName = com.Cmp_Name,
                                CompnayShort = com.Cmp_ShortName,
                                DivisionID = div.Division_ID,
                                DivisionName = div.Division_Name,
                                DepartmentID = dep.Dept_ID,
                                DepartmentName = dep.Dept_Name,
                                SectionID = sec.Section_Id,
                                SectionName = sec.Section_Name,
                                UserID = userSec == null ? 0 : userSec.CA_UserID,
                                isSelected = userSec == null ? false : true,

                            };
            return dataQuery;
        }

        public async Task<RResult> SaveUserDepartmentAccess(List<UserDepartmentAccess> entities)
        {
            RResult rResult = new();
            try
            {
                var dbData = await _dbCon.UserDepartmentAccess.Where(x => x.CA_UserID == entities.First().CA_UserID).ToListAsync();
                // Delete children
                foreach (var data in dbData)
                {
                    if (!entities.Any(c => c.SectionID == data.SectionID))
                    {
                        _dbCon.Remove(data);
                    }
                }
                // Insert child
                foreach (var data in entities)
                {
                    var existingChild = dbData.Where(c => c.SectionID == data.SectionID).FirstOrDefault();
                    if (existingChild == null)
                    {
                        _dbCon.Add(data);
                    }
                }
                await _dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}

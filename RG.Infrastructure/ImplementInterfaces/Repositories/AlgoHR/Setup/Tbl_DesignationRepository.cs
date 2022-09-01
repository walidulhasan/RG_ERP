using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class Tbl_DesignationRepository : GenericRepository<Tbl_Designation>, ITbl_DesignationRepository
    {
        private readonly AlgoHRDBContext _dbCon;

        public Tbl_DesignationRepository(AlgoHRDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<SelectListItem>> DDLDesignation(int? officeDivisionID, int? departmentID, int? sectionID, CancellationToken cancalletionToken = default)
        {
            var query = _dbCon.vw_ERP_EmpShortInfo
                         .Where(x => x.EmployeeID > 0);
            if (officeDivisionID.HasValue && officeDivisionID > 0)
            {
                query = query.Where(x => x.DivisionID == officeDivisionID);
            }
            if (departmentID.HasValue && departmentID > 0)
            {
                query = query.Where(x => x.DepartmentID == departmentID);
            }
            if (sectionID.HasValue && sectionID > 0)
            {
                query = query.Where(x => x.SectionID == sectionID);
            }

            var data = await query.Select(x => new SelectListItem
            {
                Text = x.DesignationName.Trim(),
                Value = x.DesignationID.ToString()
            }).Distinct().ToListAsync(cancalletionToken);

            return data;
        }

        public async Task<List<SelectListItem>> DDLDesignation(List<int> officeDivisionID, List<int> departmentID, List<int> sectionID, string Predict = null, CancellationToken cancalletionToken = default)
        {
            var query = _dbCon.vw_ERP_EmpShortInfo
                       .Where(x => x.EmployeeID > 0);

            if (officeDivisionID != null && officeDivisionID.Count > 0)
            {
                query = query.Where(x => officeDivisionID.Contains(x.DivisionID));
            }
            if (departmentID != null && departmentID.Count > 0)
            {
                query = query.Where(x => departmentID.Contains(x.DepartmentID));
            }
            if (sectionID != null && sectionID.Count > 0)
            {
                query = query.Where(x => sectionID.Contains(x.SectionID));
            }
            if (!string.IsNullOrWhiteSpace(Predict))
            {
                query = query.Where(b => b.DesignationName.StartsWith(Predict));
            }

            var _query = query.ToQueryString();
            var data = await query.Select(x => new SelectListItem
            {
                Text = x.DesignationName.Trim(),
                Value = x.DesignationID.ToString()
            }).Distinct().ToListAsync(cancalletionToken);

            return data;
        }

        public async Task<List<IdNamePairRM>> DDLDesignationLookup(List<int> CompanyID, List<int> officeDivisionID, List<int> departmentID, List<int> sectionID, string Predict = null, CancellationToken cancalletionToken = default)
        {
            var activeEmpQuery = from e in _dbCon.Tbl_Emp
                                 where e.Emp_Active == true
                                 select new
                                 {
                                     DesignationID = e.Emp_Designation,
                                     DepartmentID = e.Emp_Dept,
                                     SectionID = e.Emp_Section??0
                                 };
                                 
            var query = from des in _dbCon.Tbl_Designation
                        join emp in activeEmpQuery on  des.Designation_Id equals emp.DesignationID
                        join dep in _dbCon.Tbl_Dept on emp.DepartmentID equals dep.Dept_ID
                        join div in _dbCon.Tbl_Division on dep.Dept_Division equals div.Division_ID
                        join com in _dbCon.Tbl_Company on div.Division_Company equals com.Cmp_ID
                     //  where emp.Emp_Active==true
                        select new
                        {
                            CompanyID = com.EmbroCompanyID,
                            DivisionID = div.Division_ID,
                            DepartmentID = dep.Dept_ID,
                            SectionID = emp.SectionID,
                            DesignationID = des.Designation_Id,
                            DesignationName = des.Designation_Name
                        };


            if (CompanyID != null && CompanyID.Count > 0)
            {
                query = query.Where(x => CompanyID.Contains(x.CompanyID));
            }

            if (officeDivisionID != null && officeDivisionID.Count > 0)
            {
                query = query.Where(x => officeDivisionID.Contains(x.DivisionID));
            }
            if (departmentID != null && departmentID.Count > 0)
            {
                query = query.Where(x => departmentID.Contains(x.DepartmentID));
            }
            if (sectionID != null && sectionID.Count > 0)
            {
                query = query.Where(x => sectionID.Contains(x.SectionID));
            }
            if (!string.IsNullOrWhiteSpace(Predict))
            {
                query = query.Where(b => b.DesignationName.StartsWith(Predict));
            }
             
            var gropuQuery = from gd in query
                             group gd by new { gd.DesignationID, gd.DesignationName } into gpd
                             select new IdNamePairRM()
                             {
                                 ID = gpd.Key.DesignationID,
                                 Name = gpd.Key.DesignationName
                             };
            //var strquery = gropuQuery.ToQueryString();
            return await gropuQuery.ToListAsync(cancalletionToken);

            
        }

        public async Task<List<IdNamePairRM>> DDLSectionDesignationLookup(List<int> sectionID, string Predict = null, CancellationToken cancalletionToken = default)
        {
            var activeEmpQuery = from e in _dbCon.Tbl_Emp
                                 where e.Emp_Active == true
                                 select new
                                 {
                                     DesignationID = e.Emp_Designation,
                                     DepartmentID = e.Emp_Dept,
                                     SectionID = e.Emp_Section ?? 0
                                 };

            var query = from des in _dbCon.Tbl_Designation
                        join emp in activeEmpQuery on des.Designation_Id equals emp.DesignationID
                        join dep in _dbCon.Tbl_Dept on emp.DepartmentID equals dep.Dept_ID
                        join div in _dbCon.Tbl_Division on dep.Dept_Division equals div.Division_ID
                        join com in _dbCon.Tbl_Company on div.Division_Company equals com.Cmp_ID
                        //  where emp.Emp_Active==true
                        select new
                        {
                            CompanyID = com.EmbroCompanyID,
                            DivisionID = div.Division_ID,
                            DepartmentID = dep.Dept_ID,
                            SectionID = emp.SectionID,
                            DesignationID = des.Designation_Id,
                            DesignationName = des.Designation_Name
                        };
            if (sectionID != null && sectionID.Count > 0)
            {
                query = query.Where(x => sectionID.Contains(x.SectionID));
            }
            if (!string.IsNullOrWhiteSpace(Predict))
            {
                query = query.Where(b => b.DesignationName.StartsWith(Predict));
            }

            var gropuQuery = from gd in query
                             group gd by new { gd.DesignationID, gd.DesignationName,gd.SectionID,gd.DepartmentID,gd.DivisionID} into gpd
                             select new IdNamePairRM()
                             {
                                 ID = gpd.Key.DesignationID,
                                 Name = gpd.Key.DesignationName,
                                 ParentID = gpd.Key.SectionID,
                                 ParentID_1=gpd.Key.DepartmentID,
                                 ParentID_2= gpd.Key.DivisionID
                             };
            //var strquery = gropuQuery.ToQueryString();
            return await gropuQuery.ToListAsync(cancalletionToken);
        }
    }
}

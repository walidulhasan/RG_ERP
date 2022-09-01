using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class vw_ERP_EmpShortInfoRepository : GenericRepository<vw_ERP_EmpShortInfo>, Ivw_ERP_EmpShortInfoRepository
    {
        private readonly AlgoHRDBContext _dbCon;
        public vw_ERP_EmpShortInfoRepository(AlgoHRDBContext context)
            : base(context)
        {
            _dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLEmployeeList(int companyID, int officeDivisionID, int departmentID, int sectionID, int designationID, string predict = null, CancellationToken cancellationToken = default)
        {
            var query = _dbCon.vw_ERP_EmpShortInfo.Where(x => x.EmployeeID > 0);
            if (companyID > 0)
            {
                query = query.Where(x => x.EmbroCompanyID == companyID);
            }
            if (officeDivisionID > 0)
            {
                query = query.Where(x => x.DivisionID == officeDivisionID);
            }
            if (departmentID > 0)
            {
                query = query.Where(x => x.DepartmentID == departmentID);
            }
            if (sectionID > 0)
            {
                query = query.Where(x => x.SectionID == sectionID);
            }
            if (designationID > 0)
            {
                query = query.Where(x => x.DesignationID == designationID);
            }
            if (!string.IsNullOrWhiteSpace(predict))
            {
                query = query.Where(b => b.EmployeeName.Contains(predict)
                   || b.EmployeeCode.Contains(predict)
                  );
            }
            var data = await query.Select(x => new SelectListItem
            {
                Text = $"{x.EmployeeCode} - {x.EmployeeName}",
                Value = x.EmployeeID.ToString(),
                Group = new SelectListGroup() { Name = x.DepartmentName }
            }).Distinct().Take(500).ToListAsync(cancellationToken);

            return data;
        }

        public async Task<List<SelectListItem>> DDLEmployeeList(string predict = null, CancellationToken cancellationToken = default)
        {
            var dataquery = _dbCon.vw_ERP_EmpShortInfo
                    .Where(b => b.EmbroCompanyID.Value > 0);

            if (!string.IsNullOrWhiteSpace(predict))
            {
                dataquery = dataquery.Where(b => b.EmployeeName.Contains(predict)
                   || b.EmployeeCode.Contains(predict)
                  );
            }

            var data = dataquery.Select(s => new SelectListItem()
            {
                Text = $"{s.EmployeeCode} - {s.EmployeeName}",
                Value = s.EmployeeCode,
                Group = new SelectListGroup() { Name = s.DepartmentName }
            });

            return await data.ToListAsync(cancellationToken);
        }

        public async Task<vw_ERP_EmpShortInfo> Get_ERP_EmpShortInfo(string empCode = null, long? employeeID = 0, CancellationToken cancellationToken = default)
        {
            var query = _dbCon.vw_ERP_EmpShortInfo.AsQueryable();
            if (!string.IsNullOrWhiteSpace(empCode))
            {
                query = query.Where(b => b.EmployeeCode.Trim() == empCode.Trim());
            }
           else if (employeeID.HasValue == true && employeeID.Value > 0)
            {
                query = query.Where(b => b.EmployeeID == employeeID);
            }
            else
            {

            }
            var data = await query.FirstOrDefaultAsync(cancellationToken);

            return data;
        }
    }
}

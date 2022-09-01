using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.AlgoHR.Business.Vw_OutSideTask.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class Vw_OutSideTaskRepository : GenericRepository<Vw_OutSideTask>, IVw_OutSideTaskRepository
    {
        private AlgoHRDBContext dbCon;
        private readonly ICurrentUserService currentUserService;

        public Vw_OutSideTaskRepository(AlgoHRDBContext context,ICurrentUserService _currentUserService)
            : base(context)
        {
            dbCon = context;
            currentUserService = _currentUserService;
        }
        public IQueryable<Vw_OutSideTask> GetEmpOutsideTaskApplications(OutSideTaskSearchQM searchModel, CancellationToken cancellationToken)
        {
            try
            {
                var query = dbCon.Vw_OutSideTask.Where(x => x.OutSideTaskID > 0);

                if (searchModel.Employees.Any())
                {
                    query = query.Where(x => searchModel.Employees.Contains(x.EmployeeID));
                }
                else if (searchModel.Sections.Any())
                {
                    query = query.Where(x => searchModel.Sections.Contains(x.SectionID));
                }
                else if (searchModel.Departmetns.Any())
                {
                    query = query.Where(x => searchModel.Departmetns.Contains(x.DepartmentID));
                }
                else if (searchModel.Divisions.Any())
                {
                    query = query.Where(x => searchModel.Divisions.Contains(x.DivisionID));
                }
                else if (searchModel.Companies.Any())
                {
                    query = query.Where(x => searchModel.Companies.Contains(x.EmbroCompanyID));
                }

                query = query.Where(x => x.IsApproved == searchModel.ApplicationStatus && x.OutsideTaskDate.Date >= searchModel.DateFrom.Date && x.OutsideTaskDate.Date <= searchModel.DateTo.Date);
                query = from q in query
                        join da in dbCon.UserDepartmentAccess on q.SectionID equals da.SectionID
                        where da.CA_UserID == currentUserService.UserID
                        select q;

                return query;
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
    }
}

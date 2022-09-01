using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.EMS.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.EMS.Setup
{
    public interface ITbl_PeriodRepository : IGenericRepository<Tbl_Period>
    {
        Task<List<SelectListItem>> DDLWeekPeriod(int year, int month, CancellationToken cancellationToken);
    }
}

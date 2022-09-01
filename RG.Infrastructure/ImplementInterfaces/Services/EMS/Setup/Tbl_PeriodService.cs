using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.EMS.Setup;
using RG.Application.Interfaces.Services.EMS.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.EMS.Setup
{
    public class Tbl_PeriodService : ITbl_PeriodService
    {
        private readonly ITbl_PeriodRepository _tbl_PeriodRepository;

        public Tbl_PeriodService(ITbl_PeriodRepository tbl_PeriodRepository)
        {
            _tbl_PeriodRepository = tbl_PeriodRepository;
        }
        public async Task<List<SelectListItem>> DDLWeekPeriod(int year, int month, CancellationToken cancellationToken)
        {
            return await _tbl_PeriodRepository.DDLWeekPeriod(year, month, cancellationToken);
        }
    }
}

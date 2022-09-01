using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.EMS.Setup
{
    public interface ITbl_PeriodService
    {
        Task<List<SelectListItem>> DDLWeekPeriod(int year, int month, CancellationToken cancellationToken);
    }
}

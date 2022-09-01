using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.EMS.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.EMS.Setups.bl_Periods.Queries
{
    public class GetDDLWeekPeriodQuery:IRequest<List<SelectListItem>>
    {
        public int Year { get; set; }
        public int Month { get; set; }
    }
    public class GetDDLWeekPeriodQueryHandler : IRequestHandler<GetDDLWeekPeriodQuery, List<SelectListItem>>
    {
        private readonly ITbl_PeriodService _tbl_PeriodService;

        public GetDDLWeekPeriodQueryHandler(ITbl_PeriodService tbl_PeriodService)
        {
            _tbl_PeriodService = tbl_PeriodService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLWeekPeriodQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_PeriodService.DDLWeekPeriod(request.Year, request.Month, cancellationToken);
        }
    }
}

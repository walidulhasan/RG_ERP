using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Queries
{
    public class GetAllDailyProductionHourQuery : IRequest<LoadResult>
    {
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetAllDailyProductionHourQueryHandler : IRequestHandler<GetAllDailyProductionHourQuery, LoadResult>
    {
        private readonly IDailyProductionHourService _dailyProductionHourService;

        public GetAllDailyProductionHourQueryHandler(IDailyProductionHourService dailyProductionHourService)
        {
            _dailyProductionHourService = dailyProductionHourService;
        }
        public async Task<LoadResult> Handle(GetAllDailyProductionHourQuery request, CancellationToken cancellationToken)
        {
            var dataQuery = _dailyProductionHourService.GetAllGridData();
            return await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);
        }
    }
}

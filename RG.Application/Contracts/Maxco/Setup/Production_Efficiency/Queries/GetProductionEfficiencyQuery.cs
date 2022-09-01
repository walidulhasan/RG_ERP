using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Queries
{
    public class GetProductionEfficiencyQuery : IRequest<LoadResult>
    {
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetProductionEfficiencyQueryHandler : IRequestHandler<GetProductionEfficiencyQuery, LoadResult>
    {
        private readonly IProductionEfficiencyService _productionEfficiencyService;

        public GetProductionEfficiencyQueryHandler(IProductionEfficiencyService productionEfficiencyService)
        {
            _productionEfficiencyService = productionEfficiencyService;
        }
        public async Task<LoadResult> Handle(GetProductionEfficiencyQuery request, CancellationToken cancellationToken)
        {
            request.LoadOptions.PrimaryKey = new[] { "ID" };
            request.LoadOptions.PaginateViaPrimaryKey = true;
            var dataQuery = _productionEfficiencyService.GetAllGridData();
            var date = await dataQuery.ToListAsync();
            var finalData = await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);
            return finalData;
        }
    }
}

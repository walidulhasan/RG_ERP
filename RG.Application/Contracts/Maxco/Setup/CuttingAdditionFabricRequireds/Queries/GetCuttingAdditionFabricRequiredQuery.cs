using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Queries
{
    public class GetCuttingAdditionFabricRequiredQuery : IRequest<LoadResult>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public long OrderID { get; set; } = 0;
        public int BuyerID { get; set; } = 0;
        public DataSourceLoadOptions LoadOptions { get; set; }
    }

    internal class GetCuttingAdditionFabricRequiredQueryHandler : IRequestHandler<GetCuttingAdditionFabricRequiredQuery, LoadResult>
    {
        private readonly ICuttingAdditionFabricRequiredService _cuttingAdditionFabricRequiredService;

        public GetCuttingAdditionFabricRequiredQueryHandler(ICuttingAdditionFabricRequiredService cuttingAdditionFabricRequiredService)
        {
            _cuttingAdditionFabricRequiredService = cuttingAdditionFabricRequiredService;
        }
        public async Task<LoadResult> Handle(GetCuttingAdditionFabricRequiredQuery request, CancellationToken cancellationToken)
        {
            request.LoadOptions.PrimaryKey = new[] { "ID" };
            request.LoadOptions.PaginateViaPrimaryKey = true;
            var dataQuery = _cuttingAdditionFabricRequiredService.GetCuttingAdditionFabricRequiredList(request.DateFrom, request.DateTo, request.BuyerID, request.OrderID);
            var date = await dataQuery.ToListAsync();
            var finalData = await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);
            return finalData;
        }
    }
}

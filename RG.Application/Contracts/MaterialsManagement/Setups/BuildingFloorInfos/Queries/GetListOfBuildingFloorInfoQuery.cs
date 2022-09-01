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

namespace RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Queries
{
    public class GetListOfBuildingFloorInfoQuery : IRequest<LoadResult>
    {
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetListOfBuildingFloorInfoQueryHandler : IRequestHandler<GetListOfBuildingFloorInfoQuery, LoadResult>
    {
        private readonly IBuildingFloorInfoService _buildingFloorInfoService;

        public GetListOfBuildingFloorInfoQueryHandler(IBuildingFloorInfoService buildingFloorInfoService)
        {
            _buildingFloorInfoService = buildingFloorInfoService;
        }
        public async Task<LoadResult> Handle(GetListOfBuildingFloorInfoQuery request, CancellationToken cancellationToken)
        {
            var dataQuery = _buildingFloorInfoService.GetListOfBuildingFloorInfo();
            return await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);
        }
    }
}

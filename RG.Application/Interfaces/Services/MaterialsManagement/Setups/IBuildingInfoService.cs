using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public  interface IBuildingInfoService
    {
        Task<List<SelectListItem>> DDLFloorTypeWiseBuilding(int FloorType, string predict, CancellationToken cancellationToken);
        Task<BuildingInfoRM> BuildingFloorWiseBuildingInfo(int budlingFloorID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> BuildingTypeWiseBuildingInfo(int ID, string predict, CancellationToken cancellationToken);
    }
}

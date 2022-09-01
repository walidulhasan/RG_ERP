using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public  interface IBuildingFloorInfoService
    {
        Task<List<SelectListItem>> DDLBuildingWiseBuildingFloor(int Building, int FloorType, string predict, CancellationToken cancellationToken);
        IQueryable<BuildingFloorInfoRM> GetListOfBuildingFloorInfo();
        Task<RResult> BuildingFloorInfoCreate(BuildingFloorInfoDTM DTmodel, bool saveChange);
        Task<RResult> BuildingFloorInfoUpdate(BuildingFloorInfoDTM DTmodelUpdate, bool saveChange);
        Task<RResult> BuildingFloorInfoRemove(int BuildingFloorID, bool saveChange);
    }
}

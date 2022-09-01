using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Queries.RequestResponseModel;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public  interface IBuildingFloorInfoRepository : IGenericRepository<BuildingFloorInfo>
    {
        Task<List<SelectListItem>> DDLBuildingWiseBuildingFloor(int Building, int FloorType, string predict, CancellationToken cancellationToken);
        IQueryable<BuildingFloorInfoRM> GetListOfBuildingFloorInfo();
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public  interface IBuildingInfoRepository : IGenericRepository<BuildingInfo>
    {
        Task<List<SelectListItem>> DDLFloorTypeWiseBuilding(int FloorType, string predict, CancellationToken cancellationToken);
        Task<BuildingInfo> BuildingFloorWiseBuildingInfo(int budlingFloorID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> BuildingTypeWiseBuildingInfo(int ID, string predict, CancellationToken cancellationToken);
    }
}

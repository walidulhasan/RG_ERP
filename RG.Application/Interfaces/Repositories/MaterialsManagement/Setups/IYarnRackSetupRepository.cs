using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public interface IYarnRackSetupRepository : IGenericRepository<YarnRackSetup>
    {
        Task<List<SelectListItem>> DDLBuildingFloorWiseRack(int buildingFloorID, CancellationToken cancellationToken);
        Task<List<YarnRackSetup>> GetFloorWiseRackInfo(int buildingFloorID, CancellationToken cancellationToken);
        Task<RResult> Remove(int rackID, CancellationToken cancellationToken);
        Task<RResult> UpdateRackAllDetail(YarnRackSetup entity, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLLotNowithRackWiseLotno(int RackID,string predict, CancellationToken cancellationToken);
    }
}

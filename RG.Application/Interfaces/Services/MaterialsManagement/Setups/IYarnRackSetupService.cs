using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Queries.RequestResponseModel;
using RG.Application.ViewModel.MaterialsManagement.Setup;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public  interface IYarnRackSetupService
    {
        Task<RResult> Create(YarnRackCreateVM model, bool saveChange = true);
        Task<List<SelectListItem>> DDLBuildingFloorWiseRack(int buildingFloorID, CancellationToken cancellationToken);
        Task<List<YarnRackSetupInfoRM>> GetFloorWiseRackInfo(int buildingFloorID, CancellationToken cancellationToken);
        Task<RResult> Remove(int rackID, CancellationToken cancellationToken);
        Task<YarnRackCreateVM> GetDataToUpdate(int id, CancellationToken cancellationToken);
        Task<RResult> UpdateRackAllDetail(YarnRackCreateVM model, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLLotNowithRackWiseLotno(int RackID,string predict, CancellationToken cancellationToken);
    }
}

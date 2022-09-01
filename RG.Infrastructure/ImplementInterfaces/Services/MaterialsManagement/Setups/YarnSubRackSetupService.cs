using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class YarnSubRackSetupService: IYarnSubRackSetupService
    {
        private readonly IYarnSubRackSetupRepository _yarnSubRackSetupRepository;

        public YarnSubRackSetupService(IYarnSubRackSetupRepository yarnSubRackSetupRepository)
        {
            _yarnSubRackSetupRepository = yarnSubRackSetupRepository;
        }

        public async Task<List<DropDownItem>> CustomDDLRackWiseSubRack(int rackID, bool withStorageLimit = false, CancellationToken cancellationToken = default)
        {
            return await _yarnSubRackSetupRepository.CustomDDLRackWiseSubRack(rackID, withStorageLimit, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLRackWiseSubRack(int rackID, bool withStorageLimit = false, CancellationToken cancellationToken=default)
        {
            return await _yarnSubRackSetupRepository.DDLRackWiseSubRack(rackID,withStorageLimit, cancellationToken);
        }
    }
}

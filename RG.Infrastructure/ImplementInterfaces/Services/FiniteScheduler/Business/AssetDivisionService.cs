using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Business
{
    public class AssetDivisionService : IAssetDivisionService
    {
        private readonly IAssetDivisionRepository _assetDivisionRepository;

        public AssetDivisionService(IAssetDivisionRepository assetDivisionRepository)
        {
            _assetDivisionRepository = assetDivisionRepository;
        }
        public async Task<List<SelectListItem>> EmbroCompanyWiseDDLDivision(int embroCompanyID, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _assetDivisionRepository.EmbroCompanyWiseDDLDivision(embroCompanyID,Predict,cancellationToken);
        }
    }
}

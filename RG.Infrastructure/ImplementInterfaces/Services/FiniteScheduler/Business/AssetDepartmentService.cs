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
    public class AssetDepartmentService : IAssetDepartmentService
    {
        private readonly IAssetDepartmentRepository _assetDepartmentRepository;

        public AssetDepartmentService(IAssetDepartmentRepository assetDepartmentRepository)
        {
            _assetDepartmentRepository = assetDepartmentRepository;
        }
        public async Task<List<SelectListItem>> GetDivisionWiseDDLDepartment(int DivisionWiseID, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _assetDepartmentRepository.GetDivisionWiseDDLDepartment(DivisionWiseID,Predict,cancellationToken);
        }
    }
}

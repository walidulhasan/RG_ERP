using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Embro.Setups.SupplierSetups.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class SupplierSetupService : ISupplierSetupService
    {
        private readonly ISupplierSetupRepository supplierSetupRepository;
        private readonly IMapper mapper;

        public SupplierSetupService(ISupplierSetupRepository _supplierSetupRepository
            , IMapper _mapper)
        {
            supplierSetupRepository = _supplierSetupRepository;
            mapper = _mapper;
        }
        public async Task<List<SelectListItem>> DDLGetSupplierList(int companyID, List<int> AccCategoryID =null, List<int> NotInSupplier = null, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await supplierSetupRepository.DDLGetSupplierList(companyID,AccCategoryID,NotInSupplier,Predict,cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLSuppliers(int companyID, List<int> AccCategoryID = null, List<int> NotInSupplier = null, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await supplierSetupRepository.DDLSuppliers(companyID, AccCategoryID, NotInSupplier, Predict, cancellationToken);
        }

        public async Task<SupplierSetupRM> GetSupplierInfo(int id)
        {
            var entity = await supplierSetupRepository.GetByIdAsync((decimal)id);
            var model = mapper.Map<SupplierSetup, SupplierSetupRM>(entity);
            return model;
        }
    }
}

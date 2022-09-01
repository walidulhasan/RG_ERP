using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class BasicCOAService : IBasicCOAService
    {
        private readonly IBasicCOARepository _basicCOARepository;
        private readonly IMapper mapper;
        private readonly ICurrentUserService _currentUserService;

        public BasicCOAService(IBasicCOARepository basicCOARepository, IMapper _mapper,ICurrentUserService currentUserService)
        {
            _basicCOARepository = basicCOARepository;
            mapper = _mapper;
            _currentUserService = currentUserService;
        }
        public async Task<List<SelectListItem>> DDLChartOfAccounts(int? ParentID, int LevelID = 0, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _basicCOARepository.DDLChartOfAccounts(ParentID,LevelID,Predict,cancellationToken);
        }
        public async Task<List<SelectListItem>> DDLChartOfAccounts(int CompanyID, int LevelID, string Category = null, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _basicCOARepository.DDLChartOfAccounts(CompanyID, LevelID,Category ,Predict, cancellationToken);
        }
        public async Task<List<SelectListItem>> DDLGetCompanyWiseCostCenterList(int companyId)
        {
            return await _basicCOARepository.DDLGetCompanyWiseCostCenterList(companyId);
        }

        public async Task<List<SelectListItem>> DDLGetCompanyWiseKnitterList(int companyId)
        {
            return await _basicCOARepository.DDLGetCompanyWiseKnitterList(companyId);
        }

        public async Task<List<SelectListItem>> DDLGetCostcenterWiseActivityList(decimal costCenterId)
        {
            return await _basicCOARepository.DDLGetCostcenterWiseActivityList(costCenterId);
        }

        public async Task<List<SelectListItem>> DDLGetCostcenterWiseLocationList(decimal costCenterId)
        {
            return await _basicCOARepository.DDLGetCostcenterWiseLocationList(costCenterId);
        }

        public async Task<List<SelectListItem>> GetDDLCreditorsSupplior(int CompanyID = 0)
        {
            return await _basicCOARepository.GetDDLCreditorsSupplior(CompanyID);
        }

        public async Task<List<SelectListItem>> DDLYarn_CommercialKnitters_Companywise(int CompanyID)
        {
            return await _basicCOARepository.DDLYarn_CommercialKnitters_Companywise(CompanyID);
        }

        public async Task<BasicCOARM> GetBasicCOAByID(decimal ID, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _basicCOARepository.GetBasicCOAByID(ID, cancellationToken);//.GetByIdAsync(id);
                var model = mapper.Map<BasicCOA, BasicCOARM>(entity);
                return model;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<List<SelectListItem>> DDLGetReturnableNarrowGroup(int companyID, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLGetReturnableNarrowGroup(companyID, cancellationToken);
        }

        public async Task<List<BasicCOADetailRM>> GetBasicCOADetailInfo(int groupCategoryID, string predict, CancellationToken cancellationToken = default)
        {
            return await _basicCOARepository.GetBasicCOADetailInfo(groupCategoryID, _currentUserService.CompanyID, predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLCompanyWiseChartOfAccounts(int ParentID, int LevelID = 0, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _basicCOARepository.DDLCompanyWiseChartOfAccounts(ParentID, LevelID, Predict, cancellationToken);
        }
    }
}
